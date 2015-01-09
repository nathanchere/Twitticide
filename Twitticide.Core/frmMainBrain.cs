using System.Collections.Generic;

namespace Twitticide
{
    public class frmMainBrain
    {
        public frmMainBrain()
        {
            Users = new List<TwitticideAccount>();
        }

        public void LoadUsers()
        {
            //TODO: load from disk or whatever
            Users.Add(new TwitticideAccount
            {
                Id = 1680121153,
                UserName  = "nathanchere",
                DisplayName = "Nathan Chere",
            });
        }

        public List<TwitticideAccount> Users { get; set; }
    }
}