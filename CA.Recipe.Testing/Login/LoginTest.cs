using CA.Recipe.Application.Services;
using CA.Recipe.Application.Services.Port;
using CA.Recipe.Testing.User.Mock;
using CA.Recipe.Testing.WatchLater.Mock;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CA.Recipe.Testing.Login
{
    public class LoginTest
    {
        private UserService _useCase;
        [SetUp]
        public void Setup()
        {
            _useCase = new UserService(new UserGatewayMock(), new WatchLaterMock());
        }

        [Test]
        public void Login_Test()
        {
            var expectedObject = new UserResponse
            {
                id = 1,
                username = "noeshi"
            };
            var expectedValue = JsonConvert.SerializeObject(expectedObject);
            Assert.AreEqual(expectedValue, JsonConvert.SerializeObject(_useCase.Login(new UserRequest
            {
                email = "noe@gmail.com",
                password = "gato1"
            })));
        }
    }
}
