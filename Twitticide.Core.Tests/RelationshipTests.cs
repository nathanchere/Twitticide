using Xunit;

namespace Twitticide
{
    public class RelationshipTests
    {
        [Fact]
        public void Relationship_reports_NotFollowing_correctly()
        {
            var target = new Relationship();
            target.UpdateFollowStatus(false);
            Assert.Equal(Relationship.StatusEnum.NotFollowing, target.Status);
        }

        [Fact]
        public void Relationship_reports_NotFollowing_correctly_with_no_events()
        {
            var target = new Relationship();

            Assert.Equal(Relationship.StatusEnum.NotFollowing, target.Status);
        }

        [Fact]
        public void Relationship_reports_Following_correctly()
        {
            var target = new Relationship();
            target.UpdateFollowStatus(true);
            Assert.Equal(Relationship.StatusEnum.Following, target.Status);
        }

        [Fact]
        public void Relationship_reports_Following_correctly_after_refollow()
        {
            var target = new Relationship();
            target.UpdateFollowStatus(true);
            target.UpdateFollowStatus(false);
            target.UpdateFollowStatus(true);
            Assert.Equal(Relationship.StatusEnum.Following, target.Status);
        }

        [Fact]
        public void Relationship_reports_Unfollowed_correctly()
        {
            var target = new Relationship();
            target.UpdateFollowStatus(true);
            target.UpdateFollowStatus(false);
            Assert.Equal(Relationship.StatusEnum.Unfollowed, target.Status);
        }
    }
}
