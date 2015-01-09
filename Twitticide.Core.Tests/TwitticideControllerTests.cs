using System.Linq;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Xunit;

namespace Twitticide
{
    public class TwitticideControllerTests
    {
        private IFixture _fixture;

        public TwitticideControllerTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());

            var mockClient = new Mock<ITwitterClient>();
            mockClient
                .Setup(x => x.GetUser(It.IsAny<long>()))
                .Returns((long value) =>
                {
                    var result = _fixture.Create<TwitterProfile>();
                    result.Id = value;
                    return result;
                });
            
            mockClient
                .Setup(x => x.GetUser(It.IsAny<string>()))
                .Returns((string value) =>
                {
                    var result = _fixture.Create<TwitterProfile>();
                    result.UserName = value;
                    return result;
                });

            IOC.ForceInitialize();
            IOC.Bind<ITwitterClient>().ToInstance(mockClient.Object).ScopeAsTransient();
            IOC.Bind<TwitticideController>().To<TwitticideController>().ScopeAsTransient();
        }

        [Fact]
        public void Add_user_works()
        {
            var expectedId = 12345;

            var target = IOC.Resolve<TwitticideController>();
            target.AddUser(expectedId);

            var expected = target.Users.SingleOrDefault(x => x.Id == expectedId);
            Assert.NotNull(expected);
        }

        [Fact]
        public void Add_user_doesnt_overwrite_if_user_already_exists()
        {
            var expectedId = 12345;
            var target = IOC.Resolve<TwitticideController>();
            target.AddUser(expectedId);

            var expected = target.Users.Single(x => x.Id == expectedId);

            target.AddUser(expectedId);
            var expectedMatch = target.Users.Single(x => x.Id == expectedId);
            
            Assert.Equal(expected.UserName, expectedMatch.UserName);
        }
    }
}