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
        private readonly TwitticideController controller;

        public frmMain()
        {
            InitializeComponent();
            controller = IOC.Resolve<TwitticideController>();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            controller.LoadUsers();
            if (!controller.Users.Any())
            {
                ShowManageUserDialog();                
            }

            ReloadUI();
        }

        private void ReloadUI()
        {
            accountTabs.TabPages.Clear();

            foreach (var user in controller.Users)
            {
                accountTabs.TabPages.Add(user.UserName, user.UserName);

                var userControl = new TwitticideAccountControl(user);
                accountTabs.TabPages[user.UserName].Controls.Add(userControl);
                userControl.Dock = DockStyle.Fill;
            }
        }

        private void ShowManageUserDialog()
        {
            (new frmManageUsers()).ShowDialog();
        }

        private void btnManageAccounts_Click(object sender, EventArgs e)
        {
            ShowManageUserDialog();
        }
    }
}
