using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Twitticide
{
    public partial class frmManageUsers : Form
    {
        private readonly TwitticideController _controller;

        public frmManageUsers()
        {
            InitializeComponent();
        }

        public frmManageUsers(TwitticideController controller)
        {
            InitializeComponent();
            _controller = controller;
            _controller.AccountAdded += AccountsUpdated;
            _controller.AccountRemoved += AccountsUpdated;

            RefreshAccountList();
        }

        private void AccountsUpdated(object sender, TwitticideController.AccountsChangedEventArgs args)
        {
            RefreshAccountList();
        }

        private void RefreshAccountList()
        {
            lstUsers.Items.AddRange(_controller.Users);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            _controller.AddUser(txtUserName.Text);
        }
    }
}
