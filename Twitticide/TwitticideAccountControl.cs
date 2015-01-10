using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Twitticide
{
    public partial class TwitticideAccountControl : UserControl
    {
        public TwitticideAccount Account { get; private set; }
        public TwitticideController Controller { get; private set; }

        public TwitticideAccountControl(TwitticideController controller, TwitticideAccount account)
        {
            InitializeComponent();

            Account = account;
            Controller = controller;

            RefreshUI();
        }

        private void RefreshUI()
        {
            lblUserName.Text = "@" + Account.UserName;
            lblDisplayName.Text = Account.DisplayName;
            lblFollowersCount.Text = Account.FollowersCount.ToString();
            lblFollowingCount.Text = Account.FollowingCount.ToString();

            lblLastUpdated.Text = string.Format("{0} @ {1}",
                Account.LastUpdated.ToLongDateString(),
                Account.LastUpdated.ToLongTimeString());

            if (Account.ProfileImageUrl != null)
            {
                picAvatar.Load(Account.ProfileImageUrl);
                picAvatar.SizeMode = PictureBoxSizeMode.StretchImage; 
            }else picAvatar.Image = new Bitmap(1,1);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Controller.RefreshAccount(Account);
            RefreshUI();
        }

        private void btnShowFollowers_Click(object sender, EventArgs e)
        {
            ShowContacts(Account.Contacts.Values.Where(c => c.IsFollowingYou).ToArray());
        }

        private void btnShowWhoYouFollow_Click(object sender, EventArgs e)
        {
            ShowContacts(Account.Contacts.Values.Where(c => c.IsFollowedByYou).ToArray());
        }

        private void btnShowNotFollowedBy_Click(object sender, EventArgs e)
        {
            ShowContacts(
                Account.Contacts.Values.Where(c =>
                !c.IsFollowingYou && c.IsFollowedByYou
            ).ToArray());
        }

        private void btnShowNotFollowing_Click(object sender, EventArgs e)
        {
            ShowContacts(
                Account.Contacts.Values.Where(c =>
                c.IsFollowingYou && !c.IsFollowedByYou
            ).ToArray());
        }

        private void btnShowUnfollowedBy_Click(object sender, EventArgs e)
        {
            ShowContacts(
                Account.Contacts.Values.Where(c =>
                c.InwardRelationship.Status == Relationship.StatusEnum.Unfollowed
            ).ToArray());
        }

        private void btnShowYouUnfollowed_Click(object sender, EventArgs e)
        {
            ShowContacts(
                Account.Contacts.Values.Where(c =>
                c.OutwardRelationship.Status == Relationship.StatusEnum.Unfollowed
            ).ToArray());
        }

        private void btnShowNewFollowers_Click(object sender, EventArgs e)
        {
            ShowContacts(
                Account.Contacts.Values
                .Where(c => c.InwardRelationship.Status == Relationship.StatusEnum.Following)
                .Where(c => c.InwardRelationship.GetLatestEvent().Timestamp > Account.LastClearedUpdates)
                .OrderByDescending(c => c.InwardRelationship.GetLatestEvent().Timestamp)
                .ToArray()
            );
        }

        private void btnShowYouNewlyFollowing_Click(object sender, EventArgs e)
        {
            ShowContacts(
                Account.Contacts.Values
                .Where(c => c.OutwardRelationship.Status == Relationship.StatusEnum.Following)
                .Where(c => c.OutwardRelationship.GetLatestEvent().Timestamp > Account.LastClearedUpdates)
                .OrderByDescending(c => c.OutwardRelationship.GetLatestEvent().Timestamp)
                .ToArray()
            );
        }

        private void btnResetTimeCutoff_Click(object sender, EventArgs e)
        {
            Account.LastClearedUpdates = DateTime.Now;
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller.RefreshContactProfiles(Account, false);
        }

        private void onlyGetMissingProfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controller.RefreshContactProfiles(Account);
        }

        private void ShowContacts(TwitterContact[] contacts)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(contacts);
            profileListbox.Items.Clear();
            profileListbox.Items.AddRange(contacts);
        }
    }
}
