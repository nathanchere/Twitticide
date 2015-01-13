using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Twitticide
{
    public partial class frmMain : Form
    {
        private readonly TwitticideController Controller;

        public frmMain()
        {
            InitializeComponent();
            Controller = IOC.Resolve<TwitticideController>();
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
                RootFolder = Controller.ApplicationDataPath,
                SelectedPath = Controller.ApplicationDataPath,
                ShowNewFolderButton = true,
            };
            Controller.
        }
    }
}
