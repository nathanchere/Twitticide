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
        private readonly frmMainBrain brain;

        public frmMain()
        {
            InitializeComponent();
            brain = new frmMainBrain();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            brain.LoadUsers();
            if (!brain.Users.Any())
            {
                ShowAddUserDialog();
                if(!brain.Users.Any()) Application.Exit();
            }

            ReloadUI();
        }

        private void ReloadUI()
        {
            accountTabs.TabPages.Clear();

            foreach (var user in brain.Users)
            {
                accountTabs.TabPages.Add(user.UserName, user.UserName);

                var userControl = new TwitticideAccountControl(user);
                accountTabs.TabPages[user.UserName].Controls.Add(userControl);
                userControl.Dock = DockStyle.Fill;
            }
        }

        private void ShowAddUserDialog()
        {
            MessageBox.Show("TODO: add user dialog here");
        }
    }
}
