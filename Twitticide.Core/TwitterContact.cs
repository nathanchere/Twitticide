using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitticide
{
    class TwitterContact
    {
        public long Id { get; set; }
        
        public Relationship IsFollowingYou { get; set; }
        public Relationship IsFollowedByYou { get; set; }

        /// <summary>
        /// You following them
        /// </summary>
        public Relationship OutwardRelationship{ get; set; }

        /// <summary>
        /// Them following you
        /// </summary>
        public Relationship InwardRelationship { get; set; }

        public DateTime? WhenProfileLastUpdated { get; set; }        
        public TwitterProfile Profile { get; set; }
    }
   
    public class Relationship
    {
        private class FollowEvent
        {
            public bool IsFollowing { get; set; }
            public DateTime Timestamp { get; set; }
        }

        public enum StatusEnum
        {
            NotFollowing,
            Following,
            Unfollowed,
        }

        private List<FollowEvent> Events { get; set; }

        public Relationship()
        {
            Events = new List<FollowEvent>();
        }
    }

    

    public class TwitterProfile
    {
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Bio { get; set; }
        public string Location { get; set; }

        public string Url { get; set; }
        public string ProfileImageUrl { get; set; }
        public bool IsVerified { get; set; }
    }
}
