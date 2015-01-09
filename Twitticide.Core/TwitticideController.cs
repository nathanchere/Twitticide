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
        }

        public void LoadUsers()
        {            
            _users.Clear();
            foreach(var user in _dataStore.LoadUsers()) _users.Add(user);
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
            if (AccountRemoved != null) AccountRemoved(this, new AccountsChangedEventArgs(user));
        }

        private readonly List<TwitticideAccount> _users; 
        public TwitticideAccount[] Users
        {
            get { return _users.ToArray(); }
        }
        
    }
}