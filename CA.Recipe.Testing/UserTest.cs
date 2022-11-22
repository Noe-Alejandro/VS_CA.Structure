using CA.Recipe.Application.Services;
using CA.Recipe.Application.Services.Port;
using CA.Recipe.Testing.User.Mock;
using CA.Recipe.Testing.WatchLater.Mock;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CA.Recipe.Testing
{
    public class UserTest
    {
        private UserService _useCase;
        [SetUp]
        public void Setup()
        {
            _useCase = new UserService(new UserGatewayMock(), new WatchLaterMock());
        }

        [Test]
        public void AddUser_Test()
        {
            var expectedObject = new UserResponseDB { id = 1, username = "Prueba"};
            var expectedValue = JsonConvert.SerializeObject(expectedObject);
            Assert.AreEqual(expectedValue, JsonConvert.SerializeObject(_useCase.RegisterUser(new UserRequest { username = "Prueba", email = "Prueba", password = "12345"})));
        }
    }
}
