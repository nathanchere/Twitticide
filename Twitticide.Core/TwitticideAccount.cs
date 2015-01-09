using System;
using System.Collections.Generic;
using System.Linq;
using Tweetinvi;
using Tweetinvi.Core.Interfaces;

namespace Twitticide
{
    public class TwitticideAccount
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string ProfileImageUrl { get; set; }

        public Dictionary<long,TwitterContact> Contacts { get; set; }

        public DateTime LastUpdated { get; set; }

        public TwitticideAccount()
        {
            Contacts = new Dictionary<long, TwitterContact>();
        }

        public int FollowersCount
        {
            get { return Contacts.Values.Count(c => c.IsFollowingYou); }
        }

        public int FollowingCount
        {
            get { return Contacts.Values.Count(c => c.IsFollowedByYou); }
        }

        public override string ToString()
        {
            return string.Format("{0}: {1} (\"{2}\")", Id, UserName ?? "[null]", DisplayName ?? "[null]");
        }
    }
}