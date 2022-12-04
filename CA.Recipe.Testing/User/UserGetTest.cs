using CA.Recipe.Application.Services;
using CA.Recipe.Application.Services.Port;
using CA.Recipe.Testing.User.Mock;
using CA.Recipe.Testing.WatchLater.Mock;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Recipe.Testing.User
{
    public class UserGetTest
    {
        private UserService _useCase;
        [SetUp]
        public void Setup()
        {
            _useCase = new UserService(new UserGatewayMock(), new WatchLaterMock());
        }

        [TestCase(1)]
        public void GetUser_Test(int userId)
        {
            var expectedObject = new UserGetResponse
            {
                id = 1,
                username = "noeshi",
                Email = "noe@gmail.com"
            };
            var expectedValue = JsonConvert.SerializeObject(expectedObject);
            Assert.AreEqual(expectedValue, JsonConvert.SerializeObject(_useCase.GetUser(userId)));
        }
    }
}
