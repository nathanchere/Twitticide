using System;
using System.Collections.Generic;
using Tweetinvi.Core.Interfaces;

namespace Twitticide
{
    public class TwitticideAccount
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }

        public Dictionary<long,TwitterContact> Contacts { get; set; }

        public DateTime LastUpdated { get; set; }

        public TwitticideAccount()
        {
            Contacts = new Dictionary<long, TwitterContact>();
        }

        public void Update(IUser contact)
        {
        }
    }
}