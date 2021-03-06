﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FerretLib.WinForms.Controls;

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
            
            profileListbox.DisplayMode = TwitterProfileListbox.DisplayModes.Normal;

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
            }
            else picAvatar.Image = new Bitmap(1, 1);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            var result = Controller.RefreshAccountContacts(Account);
            Log(result);
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
            var result = Controller.RefreshContactProfiles(Account, false);
            Log(result);
        }

        private void onlyGetMissingProfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = Controller.RefreshContactProfiles(Account);
            Log(result);
        }

        private void Log(RefreshProfilesResult result)
        {
            if (result.IsSuccessful)
            {
                Log(result.ProfilesRefreshedCount == 0
                    ? "No profiles updated"
                    : string.Format("Updated {0} profiles", result));
            }
            else
            {
                RageMessageBox.Show("Refresh failed", null, result.ErrorMessage);
                Log("Refresh user profiles failed!");
                Log("Reason:" + result.ErrorMessage);
            }
        }

        private void ShowContacts(TwitterContact[] contacts)
        {
            profileListbox.Items.Clear();
            profileListbox.Items.AddRange(contacts);
        }

        private void Log(RefreshAccountContactsResult accountContactsResult)
        {
            var text = new StringBuilder();
            text.AppendLine("".PadRight(30, '='));
            if (accountContactsResult.IsSuccessful)
            {
                if (accountContactsResult.NewFollowers > 0) text.AppendLine("New followers: " + accountContactsResult.NewFollowers);
                if (accountContactsResult.NewFollowing > 0) text.AppendLine("New following: " + accountContactsResult.NewFollowing);
                if (accountContactsResult.NewUnfollowers > 0) text.AppendLine("New unfollowers: " + accountContactsResult.NewUnfollowers);
                if (accountContactsResult.NewUnfollowing > 0) text.AppendLine("New unfollowing: " + accountContactsResult.NewUnfollowing);

                if (text.Length == 0) text.AppendLine("No changes detected");
                Log("Refresh completed at " + DateTime.Now);
            }
            else
            {
                RageMessageBox.Show("Refresh account failed", null, accountContactsResult.ErrorMessage);
                Log("Refresh failed!");
                Log("Reason:" + accountContactsResult.ErrorMessage);
            }

            text.AppendLine("".PadRight(30, '='));
            Log(text.ToString());
        }

        private void Log(string text)
        {
            txtLog.AppendText(text + Environment.NewLine);
        }

        private void minimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            profileListbox.DisplayMode = TwitterProfileListbox.DisplayModes.Minimal;
        }

        private void standardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            profileListbox.DisplayMode = TwitterProfileListbox.DisplayModes.Normal;
        }

        private void detailedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            profileListbox.DisplayMode = TwitterProfileListbox.DisplayModes.Detailed;
        }
    }
}
