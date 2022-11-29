using CA.Recipe.Application.Exceptions;
using CA.Recipe.Application.Services;
using CA.Recipe.Application.Services.Port;
using CA.Recipe.Testing.Recipe.Mock;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;

namespace CA.Recipe.Testing.Recipe
{
    public class RecipeGetRecipeTest
    {
        private RecipeService _useCase;
        [SetUp]
        public void Setup()
        {
            _useCase = new RecipeService(new RecipeGatewayMock());
        }

        [TestCase(1)]
        public void GetRecipe_Test(int id)
        {
            var expectedObject = new RecipeDetailResponse
            {
                RecipeId = id,
                Title = "Prueba",
                Description = "Prueba",
                Ingredients = new List<IngredientAmount>() { new IngredientAmount { Name = "Cebolla", Amount = 1 } },
                Score = 5.00f
            };
            var expectedValue = JsonConvert.SerializeObject(expectedObject);
            Assert.AreEqual(expectedValue, JsonConvert.SerializeObject(_useCase.GetRecipe(id)));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void GetRecipeInvalidId_Test(int id)
        {
            Assert.Throws<InvalidRequestException>(() => _useCase.GetRecipe(id));
        }

        [TestCase(2000)]
        public void GetRecipeNotFound_Test(int id)
        {
            Assert.Throws<EntityNotFoundException>(() => _useCase.GetRecipe(id));
        }
        /*
        [TestCase(1, "Prueba", "Prueba")]
        public void GetAllRecipe_Test(int id, string title, string description)
        {
            var expectedObject = new List<RecipeCoverResponse>()
            {
                new RecipeCoverResponse
                {
                    RecipeId = 1,
                    Title = "Prueba",
                    Description = "Prueba",
                    Score = 5.00f
                }
            };
            var expectedValue = JsonConvert.SerializeObject(expectedObject);
            Assert.AreEqual(expectedValue, JsonConvert.SerializeObject(_useCase.GetAllRecipe()));
        }
        */
    }
}
