using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using FerretLib.WinForms.Controls;

namespace Twitticide
{
    public partial class frmMain : Form
    {
        private readonly TwitticideController Controller;
        private readonly IConfigProvider Config;

        public frmMain()
        {            
            InitializeComponent();
            Controller = IOC.Resolve<TwitticideController>();
            Config = IOC.Resolve<IConfigProvider>();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (!Controller.Users.Any())
            {
                ShowManageUserDialog();                
            }

            ReloadUI();
        }

        private void ReloadUI()
        {
            accountTabs.TabPages.Clear();

            foreach (var user in Controller.Users)
            {
                accountTabs.TabPages.Add(user.UserName, user.UserName);

                var userControl = new TwitticideAccountControl(Controller, user);
                accountTabs.TabPages[user.UserName].Controls.Add(userControl);
                userControl.Dock = DockStyle.Fill;
            }
        }

        private void ShowManageUserDialog()
        {
            (new frmManageUsers(Controller)).ShowDialog();
            ReloadUI();
        }

        private void btnManageAccounts_Click(object sender, EventArgs e)
        {
            ShowManageUserDialog();
        }

        private void setDataDirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog()
            {
                Description = "Select where to save data",
                SelectedPath = Config.ApplicationDataPath,
                ShowNewFolderButton = true,
            };
            if (dialog.ShowDialog() != DialogResult.OK) return;

            Config.ApplicationDataPath = dialog.SelectedPath;
            Controller.ReloadAccounts();
        }

        private void checkRateLimitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: remove the direct tweetinvi dependency
            var limits = Controller.CheckLimits();
            var result = new StringBuilder();
            result.AppendLine(string.Format("FollowersIds: {0} of {1} (reset {2})", limits.FollowersIdsLimit.Remaining, limits.FollowersIdsLimit.Limit, SecondsToString(limits.FollowersIdsLimit.ResetDateTimeInSeconds)));
            result.AppendLine(string.Format("FriendsIds: {0} of {1} (reset {2})", limits.FriendsIdsLimit.Remaining, limits.FriendsIdsLimit.Limit, SecondsToString(limits.FriendsIdsLimit.ResetDateTimeInSeconds)));
            result.AppendLine(string.Format("UsersLookup: {0} of {1} (reset {2})", limits.UsersLookupLimit.Remaining, limits.UsersLookupLimit.Limit, SecondsToString(limits.UsersLookupLimit.ResetDateTimeInSeconds)));
            result.AppendLine(string.Format("DirectMessagesShow: {0} of {1} (reset {2})", limits.DirectMessagesShowLimit.Remaining, limits.DirectMessagesShowLimit.Limit, SecondsToString(limits.DirectMessagesShowLimit.ResetDateTimeInSeconds)));
            RageMessageBox.Show("Rate limts retrieved", "Rate limits", result.ToString(), RageMessageBox.RageMessageBoxButtons.OK, RageMessageBox.RageMessageBoxIcon.TrollDerp);
        }

        private string SecondsToString(double value)
        {
            var minutes = Math.Floor(value / 60);
            var seconds = Math.Floor(value % 60);
            return string.Format("{0}m {1}s", minutes, seconds);
        }

        private void backUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var defaultFileName = String.Format("TwitticideBackup_{0}.zip", DateTime.Now.ToString("yyyy-MM-dd_hhmmss"));
            var dialog = new SaveFileDialog
            {
                CheckPathExists = true,
                FileName = defaultFileName,
                RestoreDirectory = true,
                Title = "Select backup location",
            };
            var result = dialog.ShowDialog();
            if (result != DialogResult.OK) return;

            Controller.BackupData(dialog.FileName);
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog()
            {
                CheckFileExists = true,
                RestoreDirectory = true,
                Title = "Select file to restore",
                Filter = "Twitticide Backup|TwitticideBackup_*.zip",
            };
            var result = dialog.ShowDialog();
            if (result != DialogResult.OK) return;

            Controller.RestoreBackup(dialog.FileName);
            ReloadUI();
        }
    }
}
