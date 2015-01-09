using System;
using System.Collections.Generic;

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

        public TwitticideController(ITwitterClient twitterClient)
        {
            _client = twitterClient;

            _users = new List<TwitticideAccount>();
        }

        public void LoadUsers()
        {            
            _users.Clear();
            _users.Add(new TwitticideAccount
            {
                Id = 1680121153,
                UserName  = "nathanchere",
                DisplayName = "Nathan Chere",
            });
        }

        public void AddUser(string userName)
        {
            AddUser(_client.GetUser(userName));
        }

        public void AddUser(long userId)
        {
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

        private List<TwitticideAccount> _users; 
        public TwitticideAccount[] Users
        {
            get { return _users.ToArray(); }
        }
        
    }    
}