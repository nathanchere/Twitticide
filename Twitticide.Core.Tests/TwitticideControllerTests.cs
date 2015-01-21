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
            IOC.Bind<ITwitterClient>().ToInstance(mockClient.Object);
            IOC.Bind<IDataStore>().To<MockDataStore>();
            IOC.Bind<TwitticideController>().To<TwitticideController>();
        }

        [Fact]
        public void Add_user_works()
        {
            var expectedId = 12345;

            var target = IOC.Resolve<TwitticideController>();
            target.AddUser(expectedId);

            var expected = target.Accounts.SingleOrDefault(x => x.Id == expectedId);
            Assert.NotNull(expected);
        }

        [Fact]
        public void Add_multiple_users_works()
        {
            var expectedTotal = 3;

            var target = IOC.Resolve<TwitticideController>();
            target.AddUser(11);
            target.AddUser(12);
            target.AddUser(13);

            var expected = target.Accounts.Length;
            Assert.Equal(expectedTotal, expected);
        }

        [Fact]
        public void Add_user_doesnt_overwrite_if_user_already_exists()
        {
            var expectedId = 12345;
            var target = IOC.Resolve<TwitticideController>();
            target.AddUser(expectedId);

            var expected = target.Accounts.Single(x => x.Id == expectedId);

            target.AddUser(expectedId);
            var expectedMatch = target.Accounts.Single(x => x.Id == expectedId);
            
            Assert.Equal(expected.UserName, expectedMatch.UserName);
        }

        [Fact]
        public void Add_user_triggers_event()
        {
            var timesTriggered = 0;

            var target = IOC.Resolve<TwitticideController>();
            target.AccountAdded += (sender, args) => timesTriggered++;
            target.AddUser(12345);

            Assert.Equal(1, timesTriggered);
        }

        [Fact]
        public void Add_user_doesnt_trigger_event_if_user_already_exists()
        {            
            var timesTriggered = 0;
            var target = IOC.Resolve<TwitticideController>();
            target.AccountAdded += (sender, args) => timesTriggered++;
            target.AddUser(12345);
            target.AddUser(12345);

            Assert.Equal(1, timesTriggered);
        }

        [Fact]
        public void Remove_user_works()
        {
            const int expectedTotal = 2;

            var target = IOC.Resolve<TwitticideController>();
            target.AddUser(11);
            target.AddUser(12);
            target.AddUser(13);
            target.RemoveUser(12);

            var expected = target.Accounts.Length;
            Assert.Equal(expectedTotal, expected);
        }

        [Fact]
        public void Remove_removes_correct_user()
        {
            const int expectedId = 12345;

            var target = IOC.Resolve<TwitticideController>();
            target.AddUser(11);
            target.AddUser(12);
            target.AddUser(expectedId);
            target.AddUser(13);            

            target.RemoveUser(expectedId);

            var expected = target.Accounts.Any(x=>x.Id == expectedId);
            Assert.False(expected);
        }

        [Fact]
        public void Remove_user_triggers_event()
        {
            var timesTriggered = 0;

            var target = IOC.Resolve<TwitticideController>();
            target.AccountRemoved += (sender, args) => timesTriggered++;
            target.AddUser(11);
            target.AddUser(12);
            target.AddUser(13);
            target.RemoveUser(13);
            target.RemoveUser(11);

            Assert.Equal(2, timesTriggered);
        }

        [Fact]
        public void Remove_user_doesnt_trigger_event_if_user_doesnt_exist()
        {
            var timesTriggered = 0;

            var target = IOC.Resolve<TwitticideController>();
            target.AccountRemoved += (sender, args) => timesTriggered++;
            target.AddUser(11);
            target.AddUser(12);
            target.AddUser(13);
            target.AddUser(14);
            target.AddUser(15);

            target.RemoveUser(0);
            target.RemoveUser(13);
            target.RemoveUser(14);
            target.RemoveUser(12345);


            Assert.Equal(2, timesTriggered);
        }
    }
}