using CA.Recipe.Application.Exceptions;
using CA.Recipe.Application.Services;
using CA.Recipe.Application.Services.Port;
using CA.Recipe.Testing.User.Mock;
using CA.Recipe.Testing.WatchLater.Mock;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CA.Recipe.Testing.User
{
    public class UserRegisterTest
    {
        private UserService _useCase;
        [SetUp]
        public void Setup()
        {
            _useCase = new UserService(new UserGatewayMock(), new WatchLaterMock());
        }

        [Test]
        public void RegisterUser_Test()
        {
            var expectedObject = new UserResponse
            {
                id = 1,
                username = "noe"
            };
            var expectedValue = JsonConvert.SerializeObject(expectedObject);
            Assert.AreEqual(expectedValue, JsonConvert.SerializeObject(_useCase.RegisterUser(new UserRequest
            {
                username = "noe",
                email = "noe@gmail.com",
                password = "A12345"
            })));
        }

        [TestCase("", "", "")]
        [TestCase("noe", "", "")]
        [TestCase("noe", "noe@gmail.com", "")]
        public void RegisterUserInvalidString_Test(string username, string email, string password)
        {
            Assert.Throws<InvalidRequestException>(() => _useCase.RegisterUser(new UserRequest 
            {
                username = username,
                email = email,
                password = password
            }));
        }

        [TestCase("noe_used@gmail.com")]
        public void RegisterUserEmailInUserg_Test(string email)
        {
            Assert.Throws<EmailInUseException>(() => _useCase.RegisterUser(new UserRequest
            {
                username = "noe",
                email = email,
                password = "A12345"
            }));
        }
    }
}
