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

        public TwitticideAccountControl()
        {
            InitializeComponent();
        }

        public TwitticideAccountControl(TwitticideAccount account)
        {
            InitializeComponent();

            Account = account;
            RefreshUI();
        }

        private void RefreshUI()
        {
            lblUserName.Text = Account.UserName;
            lblDisplayName.Text = Account.DisplayName;
            lblFollowersCount.Text = "0";
            lblFollowingCount.Text = "0";
        }
    }
}
