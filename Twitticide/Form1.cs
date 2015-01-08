﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Twitticide
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        private readonly frmMainBrain brain;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            brain.LoadUsers();
            if (!brain.Users.Any())
            {
                ShowAddUserDialog();
                if(!brain.Users.Any()) Application.Exit();
            }
        }

        private void ShowAddUserDialog()
        {
            MessageBox.Show("TODO: add user dialog here");
        }
    }

    public class frmMainBrain
    {
        public void LoadUsers()
        {
            //TODO: load from disk or whatever
        }

        public List<TwitticideAccount> Users { get; set; }
    }
}
