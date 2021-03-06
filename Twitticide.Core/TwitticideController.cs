﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using Newtonsoft.Json.Bson;
using NServiceKit.Text;
using Tweetinvi.Core.Extensions;
using Tweetinvi.Core.Interfaces.Credentials;

namespace Twitticide
{
    public class TwitticideController
    {
        #region Events
        public delegate void AccountsChangedDelegate(object sender, AccountsChangedEventArgs args);
        public event AccountsChangedDelegate AccountAdded;
        public event AccountsChangedDelegate AccountRemoved;

        public class AccountsChangedEventArgs : EventArgs
        {
            public AccountsChangedEventArgs(TwitticideAccount newAccount)
            {
                Account = newAccount;
            }

            public TwitticideAccount Account { get; private set; }
        }
        #endregion

        private readonly ITwitterClient _client;
        private readonly IDataStore _dataStore;
        private readonly IConfigProvider _config;
        private readonly IImageCache _imageCache;

        public TwitticideController(ITwitterClient twitterClient, IDataStore dataStore, IConfigProvider config, IImageCache imageCache)
        {
            _client = twitterClient;
            _dataStore = dataStore;
            _config = config;
            _imageCache = imageCache;

            _users = new List<TwitticideAccount>();

            ReloadAccounts();
        }

        public void AddUser(string userName)
        {
            if (_users.Any(x => x.UserName == userName)) return;

            AddUser(_client.GetUser(userName));
        }

        public void AddUser(long userId)
        {
            if (_users.Any(x => x.Id == userId)) return;

            AddUser(_client.GetUser(userId));
        }

        private void AddUser(TwitterProfile user)
        {
            var newAccount = new TwitticideAccount
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
                UserName = user.UserName,
                LastUpdated = DateTime.MinValue,
                Contacts = new Dictionary<long, TwitterContact>(),
            };

            _dataStore.SaveAccount(newAccount);
            _users.Add(newAccount);

            if (AccountAdded != null) AccountAdded(this, new AccountsChangedEventArgs(newAccount));
        }

        public void RemoveUser(string userName)
        {
            var user = _users.SingleOrDefault(x => x.UserName == userName);
            RemoveUser(user);
        }

        public void RemoveUser(long userId)
        {
            var user = _users.SingleOrDefault(x => x.Id == userId);
            RemoveUser(user);
        }

        private void RemoveUser(TwitticideAccount user)
        {
            if (user == null) return;
            _users.Remove(user);
            _dataStore.DeleteAccount(user);
            if (AccountRemoved != null) AccountRemoved(this, new AccountsChangedEventArgs(user));
        }

        public RefreshAccountContactsResult RefreshAccountContacts(TwitticideAccount account)
        {
            var result = new RefreshAccountContactsResult();
            try
            {
                var user = _client.GetUser(account.Id);

                var followers = _client.GetFollowers(account.UserName);
                var following = _client.GetFollowing(account.UserName);

                result.TotalFollowers = followers.Length;
                result.TotalFollowing = followers.Length;

                // Update old ones
                foreach (var contact in account.Contacts.Values)
                {
                    if (!followers.Contains(contact.Id))
                    {
                        if (account.Contacts[contact.Id].InwardRelationship.Status == Relationship.StatusEnum.Following)
                            result.NewUnfollowers++;

                        account.Contacts[contact.Id].InwardRelationship.UpdateFollowStatus(false);
                    }
                    if (!following.Contains(contact.Id))
                    {
                        if (account.Contacts[contact.Id].OutwardRelationship.Status == Relationship.StatusEnum.Following)
                            result.NewUnfollowing++;

                        account.Contacts[contact.Id].OutwardRelationship.UpdateFollowStatus(false);
                    }
                }

                // Add new ones
                foreach (var followerId in followers)
                {
                    if (!account.Contacts.ContainsKey(followerId))
                    {
                        account.Contacts[followerId] = new TwitterContact(followerId);
                        result.NewFollowers++;
                    }
                    account.Contacts[followerId].InwardRelationship.UpdateFollowStatus(true);
                }
                foreach (var followingId in following)
                {
                    if (!account.Contacts.ContainsKey(followingId))
                    {
                        account.Contacts[followingId] = new TwitterContact(followingId);
                        result.NewFollowing++;
                    }
                    account.Contacts[followingId].OutwardRelationship.UpdateFollowStatus(true);
                }

                result.IsSuccessful = true;
                result.ErrorMessage = "";

                account.LastUpdated = DateTime.Now;
                account.DisplayName = user.DisplayName;
                account.UserName = user.UserName;
                account.ProfileImageUrl = user.ProfileImageUrl;

                _dataStore.SaveAccount(account);
            }
            catch (Exception ex)
            {
                _dataStore.LoadAccount(account.Id);
                result.IsSuccessful = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public RefreshProfilesResult RefreshContactProfiles(TwitticideAccount account, bool onlyNew = true)
        {
            try
            {
                var contactsToUpdate = account.Contacts.Values.ToArray();
                if (onlyNew) contactsToUpdate = contactsToUpdate.Where(x => x.Profile == null).ToArray();

                var profiles = _client.GetUsers(contactsToUpdate.Select(x => x.Id)).ToArray();

                // Check not rate limited

                foreach (var contact in contactsToUpdate)
                {
                    var profile = profiles.SingleOrDefault(p => p.Id == contact.Id);
                    if (profile == null)
                    {
                        profile = contact.Profile ?? new TwitterProfile
                        {
                            Id = contact.Id,
                            DisplayName = "[notFound]",
                            UserName = "[notFound]",
                        };
                        //if (contact == null)
                        //{
                            
                        //    profile.IsDeleted = true;
                        //}
                        //else
                        //{
                        //    profile = contact.Profile ?? new TwitterProfile
                        //    {
                        //        Id = contact.Id,
                        //        DisplayName = "[deleted] " + contact.Profile.DisplayName,
                        //        UserName = "[deleted] " + contact.Profile.UserName,
                        //    };
                        //    profile.IsDeleted = true;
                        //}
                    }
                    else
                    {
                        _imageCache.UpdateCache(profile);
                        profile.IsDeleted = false;
                    }
                    contact.Profile = profile;
                    contact.WhenProfileLastUpdated = DateTime.Now;
                }

                _dataStore.SaveAccount(account);

                return new RefreshProfilesResult
                {
                    ProfilesRefreshedCount = contactsToUpdate.Length,
                    IsSuccessful = true,
                };
            }
            catch (Exception ex)
            {
                return new RefreshProfilesResult
                {
                    IsSuccessful = false,
                    ErrorMessage = ex.Message,
                };
            }
        }        

        private readonly List<TwitticideAccount> _users;
        public TwitticideAccount[] Accounts
        {
            get { return _users.ToArray(); }
        }

        public ITokenRateLimits CheckLimits()
        {
            return _client.CheckLimits();
        }

        public void BackupData(string fileName)
        {
            _dataStore.BackupData(fileName);
        }

        public void RestoreBackup(string fileName)
        {
            _dataStore.RestoreBackup(fileName);
        }

        public void ReloadAccounts()
        {
            _users.Clear();
            foreach (var user in _dataStore.LoadAccounts()) _users.Add(user);
        }
    }
}