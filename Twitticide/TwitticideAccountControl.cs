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
        private TwitticideAccount _account;

        public TwitticideAccountControl()
        {
            InitializeComponent();
        }

        public TwitticideAccountControl(TwitticideAccount account)
        {
            _account = account;
            RefreshUI();
        }

        private void RefreshUI()
        {
            lblUserName.Text = _account.UserName;
        }
    }
}
