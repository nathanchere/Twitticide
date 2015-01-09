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
        public TwitticideController Controller{ get; private set; }

        public TwitticideAccountControl(TwitticideController controller, TwitticideAccount account)
        {
            InitializeComponent();

            Account = account;
            Controller = controller;

            RefreshUI();
        }

        private void RefreshUI()
        {
            lblUserName.Text = Account.UserName;
            lblDisplayName.Text = Account.DisplayName;
            lblFollowersCount.Text = Account.FollowersCount.ToString();
            lblFollowingCount.Text = Account.FollowingCount.ToString();

            picAvatar.Load(Account.ProfileImageUrl);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Controller.RefreshAccount(Account);
            RefreshUI();
        }
    }
}
