using CA.Recipe.Application.Exceptions;
using CA.Recipe.Application.Services;
using CA.Recipe.Application.Services.Port;
using CA.Recipe.Testing.Recipe.Mock;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Recipe.Testing.Recipe
{
    public class RecipeGetAllTest
    {
        private RecipeService _useCase;
        [SetUp]
        public void Setup()
        {
            _useCase = new RecipeService(new RecipeGatewayMock());
        }

        [Test]
        public void GetAllRecipe_Test()
        {
            var expectedObject = new List<RecipeCoverResponse>(){ new RecipeCoverResponse
            {
                RecipeId = 1,
                Title = "Prueba",
                Description = "Prueba",
                ImageUrl = "url",
                Score = 5.00f
            } };
            var expectedValue = JsonConvert.SerializeObject(expectedObject);
            Assert.AreEqual(expectedValue, JsonConvert.SerializeObject(_useCase.GetAllRecipe()));
        }
    }
}
