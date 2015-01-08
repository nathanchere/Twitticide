using NUnit.Framework;

namespace Twitticide
{
    [TestFixture]
    public class RelationshipTests
    {
        [Test]
        public void Relationship_reports_NotFollowing_correctly()
        {
            var target = new Relationship();
            target.UpdateFollowStatus(false);
            Assert.AreEqual(Relationship.StatusEnum.NotFollowing, target.Status);
        }

        [Test]
        public void Relationship_reports_NotFollowing_correctly_with_no_events()
        {
            var target = new Relationship();

            Assert.AreEqual(Relationship.StatusEnum.NotFollowing, target.Status);
        }

        [Test]
        public void Relationship_reports_Following_correctly()
        {
            var target = new Relationship();
            target.UpdateFollowStatus(true);
            Assert.AreEqual(Relationship.StatusEnum.Following, target.Status);
        }

        [Test]
        public void Relationship_reports_Following_correctly_after_refollow()
        {
            var target = new Relationship();
            target.UpdateFollowStatus(true);
            target.UpdateFollowStatus(false);
            target.UpdateFollowStatus(true);
            Assert.AreEqual(Relationship.StatusEnum.Following, target.Status);
        }

        [Test]
        public void Relationship_reports_Unfollowed_correctly()
        {
            var target = new Relationship();
            target.UpdateFollowStatus(true);
            target.UpdateFollowStatus(false);
            Assert.AreEqual(Relationship.StatusEnum.Unfollowed, target.Status);
        }
    }
}
