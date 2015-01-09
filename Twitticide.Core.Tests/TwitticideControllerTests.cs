using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;

namespace Twitticide
{
    [TestFixture]
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

            IOC.Initialize();
            IOC.Bind<ITwitterClient>().ToInstance(mockClient.Object);

            IOC.Bind<TwitticideController>().To<TwitticideController>();
        }

        [Test]
        public void Add_user_works()
        {
            var expectedId = 12345;

            var target = IOC.Resolve<TwitticideController>();
            target.AddUser(expectedId);

            var expected = target.Users.SingleOrDefault(x => x.Id == expectedId);
            Assert.NotNull(expected);
        }

        [Test]
        public void Add_user_doesnt_overwrite_if_user_already_exists()
        {
            var expectedId = 12345;
            var target = IOC.Resolve<TwitticideController>();
            target.AddUser(expectedId);

            var expected = target.Users.Single(x => x.Id == expectedId);

            target.AddUser(expectedId);
            var expectedMatch = target.Users.Single(x => x.Id == expectedId);
            
            Assert.Equals(expected.UserName, expectedMatch.UserName);
        }
    }
}