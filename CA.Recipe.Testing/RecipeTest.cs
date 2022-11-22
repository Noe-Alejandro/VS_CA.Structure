using CA.Recipe.Application.Services;
using CA.Recipe.Application.Services.Port;
using CA.Recipe.Testing.Recipe.Mock;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;

namespace CA.Recipe.Testing
{
    public class RecipeTest
    {
        private RecipeService _useCase;
        [SetUp]
        public void Setup()
        {
            _useCase = new RecipeService(new RecipeGatewayMock());
        }

        [Test]
        public void AddRecipe_Test()
        {
            var expectedObject = new RecipeResponseDB { Id = 1, Name = "Prueba", Author = "Prueba"};
            var expectedValue = JsonConvert.SerializeObject(expectedObject);
            Assert.AreEqual(expectedValue, JsonConvert.SerializeObject(_useCase.AddRecipe(new RecipeRequest { Name = "Prueba", Author = "Prueba"})));
        }

        [Test]
        public void GetRecipe_Test()
        {
            var expectedObject = new RecipeResponseDB { Id = 1, Name = "Prueba", Author = "Prueba" };
            var expectedValue = JsonConvert.SerializeObject(expectedObject);
            Assert.AreEqual(expectedValue, JsonConvert.SerializeObject(_useCase.GetRecipe(1)));
        }

        [Test]
        public void GetAllRecipe_Test()
        {
            var expectedObject = new List<RecipeResponseDB>()
            {
                new RecipeResponseDB { Id = 1, Name = "Prueba", Author = "Prueba" }
            };
            var expectedValue = JsonConvert.SerializeObject(expectedObject);
            Assert.AreEqual(expectedValue, JsonConvert.SerializeObject(_useCase.GetAllRecipe()));
        }
    }
}
