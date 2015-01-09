using System;
using System.Collections.Generic;
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
        }

        private void ShowAddUserDialog()
        {
            MessageBox.Show("TODO: add user dialog here");
        }
    }

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
