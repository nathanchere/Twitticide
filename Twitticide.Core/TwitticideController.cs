using System;
using System.Collections.Generic;

namespace Twitticide
{
    public class TwitticideController
    {
        #region Events
        public delegate void AccountChangedDelegate(object sender, EventArgs args);
        public event AccountChangedDelegate AccountsChanged;        
        #endregion

        private readonly TwitterClient _client;

        public TwitticideController()
        {
            _client = new TwitterClient();
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
        }

        public void AddUser(long userId)
        {
            var user = 
        }

        private List<TwitticideAccount> _users; 
        public TwitticideAccount[] Users
        {
            get { return _users.ToArray(); }
        }
        
    }

    
}