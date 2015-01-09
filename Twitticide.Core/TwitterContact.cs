using System;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Core.Interfaces;

namespace Twitticide
{
    public class TwitterContact
    {
        public TwitterContact()
        {
            OutwardRelationship = new Relationship();
            InwardRelationship = new Relationship();
        }

        public long Id { get; set; }
        
        /// <summary>
        /// You following them
        /// </summary>
        public Relationship OutwardRelationship { get; set; }

        /// <summary>
        /// Them following you
        /// </summary>
        public Relationship InwardRelationship { get; set; }

        public bool IsFollowedByYou
        {
            get
            {
                return OutwardRelationship.Status == Relationship.StatusEnum.Following;
            }
        }

        public bool IsFollowingYou
        {
            get {
                return InwardRelationship.Status == Relationship.StatusEnum.Following;
            }
        }

        public DateTime? WhenProfileLastUpdated { get; set; }        
        public TwitterProfile Profile { get; set; }
    }

    public class TwitterProfile
    {
        public TwitterProfile(){ }

        public TwitterProfile(IUser user)
        {
            Id = user.Id;
            UserName = user.ScreenName;
            DisplayName = user.Name;
            Bio = user.Description;
            Location = user.Location;
            IsVerified = user.Verified;
            ProfileImageUrl = user.ProfileImageUrl;
        }

        public long Id { get; set; }

        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Bio { get; set; }
        public string Location { get; set; }

        public string Url { get; set; }
        public string ProfileImageUrl { get; set; }
        public bool IsVerified { get; set; }        
    }
}
