using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Twitticide
{
    [TestFixture]
    public class TwitticideControllerTests
    {
        [Test]
        public void Add_user_works()
        {
        }

        [Test]
        public void Add_user_doesnt_overwrite_if_user_already_exists()
        {
            var target = new TwitticideController();
        }
    }
}
