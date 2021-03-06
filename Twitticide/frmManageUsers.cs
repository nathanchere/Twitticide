﻿using System;
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
        
        public frmManageUsers(TwitticideController controller)
        {
            InitializeComponent();
            _controller = controller;
            _controller.AccountAdded += AccountsUpdated;
            _controller.AccountRemoved += AccountsUpdated;            
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            RefreshAccountList();
        }

        private void AccountsUpdated(object sender, TwitticideController.AccountsChangedEventArgs args)
        {
            RefreshAccountList();
        }

        private void RefreshAccountList()
        {
            lstAccounts.Items.Clear(); 
            lstAccounts.Items.AddRange(_controller.Accounts);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.AddUser(txtUserName.Text);
            }
            catch (Exception ex)            
            {
                MessageBox.Show("Ohhh error: " + ex.Message);
            }
        }        

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            try
            {
                var account = lstAccounts.SelectedItem as TwitticideAccount;
                if (account == null) return;
                if (MessageBox.Show("Are you sure? Cannot be undone!", "Really delete?", MessageBoxButtons.YesNoCancel) != DialogResult.Yes) return;

                _controller.RemoveUser(account.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ohhh error: " + ex.Message);
            }
        }
    }
}
