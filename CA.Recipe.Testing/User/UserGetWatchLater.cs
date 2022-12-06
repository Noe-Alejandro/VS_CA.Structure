using CA.Recipe.Application.Exceptions;
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
    public class UserGetWatchLater
    {
        private UserService _useCase;
        [SetUp]
        public void Setup()
        {
            _useCase = new UserService(new UserGatewayMock(), new WatchLaterMock());
        }

        [TestCase(1)]
        public void GetWatchLater_Test(int userId)
        {
            var expectedObject = new List<RecipeCoverResponse>()
            {
                new RecipeCoverResponse { RecipeId = 1, Title = "Prueba", Description = "Prueba", ImageUrl = "url", Score = 5.00f, Author = "noeshi" },
                new RecipeCoverResponse { RecipeId = 2, Title = "Prueba 2", Description = "Prueba 2", ImageUrl = "url2", Score = 4.50f, Author = "pastito" }
            };
            var expectedValue = JsonConvert.SerializeObject(expectedObject);
            Assert.AreEqual(expectedValue, JsonConvert.SerializeObject(_useCase.ListWatchLater(userId)));
        }

        [TestCase(100)]
        public void GetWatchLaterOutRange_Test(int userId)
        {
            Assert.Throws<EntityNotFoundException>(() => _useCase.ListWatchLater(userId));
        }
    }
}
