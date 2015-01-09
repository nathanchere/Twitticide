using System;
using System.Collections.Generic;
using System.Linq;

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

        public TwitticideController(ITwitterClient twitterClient, IDataStore dataStore)
        {
            _client = twitterClient;
            _dataStore = dataStore;

            _users = new List<TwitticideAccount>(); 

            foreach(var user in _dataStore.LoadAccounts()) _users.Add(user);
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

        public void RefreshAccount(TwitticideAccount account)
        {
            var user = _client.GetUser(account.Id);

            account.LastUpdated = DateTime.Now;
            account.DisplayName = user.DisplayName;
            account.UserName = user.UserName;
            account.ProfileImageUrl = user.ProfileImageUrl;


            var followers = _client.GetFollowers(account.UserName);
            var following = _client.GetFollowing(account.UserName);

            // Update old ones
            foreach (var contact in account.Contacts.Values)
            {
                if (!followers.Contains(contact.Id)) account.Contacts[contact.Id].InwardRelationship.UpdateFollowStatus(false);
                if (!following.Contains(contact.Id)) account.Contacts[contact.Id].OutwardRelationship.UpdateFollowStatus(false);
            }

            // Add new ones
            foreach (var followerId in followers)
            {
                if (!account.Contacts.ContainsKey(followerId)) account.Contacts[followerId] = new TwitterContact(followerId);
                account.Contacts[followerId].InwardRelationship.UpdateFollowStatus(true);
            }
            foreach (var followingId in following)
            {
                if (!account.Contacts.ContainsKey(followingId)) account.Contacts[followingId] = new TwitterContact(followingId);
                account.Contacts[followingId].OutwardRelationship.UpdateFollowStatus(true);
            }
        }

        private readonly List<TwitticideAccount> _users; 
        public TwitticideAccount[] Users
        {
            get { return _users.ToArray(); }
        }
        
    }
}