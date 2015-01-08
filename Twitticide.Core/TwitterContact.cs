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
