using CA.Recipe.Application.Exceptions;
using CA.Recipe.Application.Services;
using CA.Recipe.Application.Services.Port;
using CA.Recipe.Testing.Recipe.Mock;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;

namespace CA.Recipe.Testing.Writer
{
    public class WriterCreateRecipeTest
    {
        private WriterService _useCase;
        [SetUp]
        public void Setup()
        {
            _useCase = new WriterService(new RecipeGatewayMock());
        }

        [TestCase("Empanadas", "Ricas empanadas", 1)]
        public void CreateRecipe_Test(string name, string description, int portion)
        {
            var expectedObject = new RecipeResponseDB { Id = 1, Name = "Empanadas" };
            var expectedValue = JsonConvert.SerializeObject(expectedObject);
            Assert.AreEqual(expectedValue, JsonConvert.SerializeObject(_useCase.CreateRecipe(new RecipeRequest
            {
                Name = name,
                Description = description,
                Ingredients = new List<IngredientRequest>() { new IngredientRequest { IngredientId = 1 } },
                Portions = portion,
                Image = "",
                Steps = "Cocinar"
            })));
        }

        [TestCase("", "")]
        [TestCase("Empanadas", "")]
        [TestCase("", "Ricas empanadas")]
        public void CreateRecipeInvalidString_Test(string name, string description)
        {
            Assert.Throws<InvalidRequestException>(() => _useCase.CreateRecipe(new RecipeRequest
            {
                Name = name,
                Description = description,
                Ingredients = new List<IngredientRequest>() { new IngredientRequest { IngredientId = 1 } },
                Portions = 1,
                Image = "",
                Steps = "Cocinar"
            }));
        }

        [TestCase("Empanadas", "Ricas empanadas", 0)]
        [TestCase("Empanadas", "Ricas empanadas", -1)]
        public void CreateRecipeInvalidInt_Test(string name, string description, int portion)
        {
            Assert.Throws<InvalidRequestException>(() => _useCase.CreateRecipe(new RecipeRequest
            {
                Name = name,
                Description = description,
                Ingredients = new List<IngredientRequest>() { new IngredientRequest { IngredientId = 1 } },
                Portions = portion,
                Image = "",
                Steps = "Cocinar"
            }));
        }

        [TestCase("Empanadas", "Ricas empanadas")]
        public void CreateRecipeInvalidIngredients_Test(string name, string description)
        {
            Assert.Throws<InvalidRequestException>(() => _useCase.CreateRecipe(new RecipeRequest
            {
                Name = name,
                Description = description,
                Ingredients = null,
                Portions = 1,
                Image = "",
                Steps = "Cocinar"
            }));
        }

        [TestCase("Empanadas", "Ricas empanadas")]
        public void CreateRecipeInvalidSteps_Test(string name, string description)
        {
            Assert.Throws<InvalidRequestException>(() => _useCase.CreateRecipe(new RecipeRequest
            {
                Name = name,
                Description = description,
                Ingredients = new List<IngredientRequest>() { new IngredientRequest { IngredientId = 1 } },
                Portions = 1,
                Image = "",
                Steps = null
            }));
        }
    }
}
