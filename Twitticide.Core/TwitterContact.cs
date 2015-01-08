using System;
using System.Text;
using System.Threading.Tasks;

namespace Twitticide
{
    class TwitterContact
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

        public DateTime? WhenProfileLastUpdated { get; set; }        
        public TwitterProfile Profile { get; set; }
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
