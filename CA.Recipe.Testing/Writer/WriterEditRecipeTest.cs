using CA.Recipe.Application.Exceptions;
using CA.Recipe.Application.Services;
using CA.Recipe.Application.Services.Port;
using CA.Recipe.Testing.Recipe.Mock;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;

namespace CA.Recipe.Testing.Writer
{
    public class WriterEditRecipeTest
    {
        private WriterService _useCase;
        [SetUp]
        public void Setup()
        {
            _useCase = new WriterService(new RecipeGatewayMock());
        }

        [TestCase("Update Empanadas", "Update Ricas empanadas", 1, ExpectedResult = true)]
        public bool EditRecipe_Test(string name, string description, int portion)
        {
            return _useCase.EditRecipe(1, new RecipeRequest
            {
                Name = name,
                Description = description,
                Ingredients = new List<IngredientRequest>() { new IngredientRequest { IngredientId = 1 } },
                Portions = portion,
                Image = "",
                Steps = new List<StepRequest>() { new StepRequest { Step = "Cocinar" } }
            });
        }

        [TestCase("Empanadas", "Ricas empanadas")]
        public void EditRecipeInvalidId_Test(string name, string description)
        {
            Assert.Throws<EntityNotFoundException>(() => _useCase.EditRecipe(2, new RecipeRequest
            {
                Name = name,
                Description = description,
                Ingredients = new List<IngredientRequest>() { new IngredientRequest { IngredientId = 1 } },
                Portions = 1,
                Image = "",
                Steps = new List<StepRequest>() { new StepRequest { Step = "Cocinar" } }
            }));
        }

        [TestCase("", "")]
        [TestCase("Empanadas", "")]
        [TestCase("", "Ricas empanadas")]
        public void EditRecipeInvalidString_Test(string name, string description)
        {
            Assert.Throws<InvalidRequestException>(() => _useCase.EditRecipe(1, new RecipeRequest
            {
                Name = name,
                Description = description,
                Ingredients = new List<IngredientRequest>() { new IngredientRequest { IngredientId = 1 } },
                Portions = 1,
                Image = "",
                Steps = new List<StepRequest>() { new StepRequest { Step = "Cocinar" } }
            }));
        }

        [TestCase("Empanadas", "Ricas empanadas", 0)]
        [TestCase("Empanadas", "Ricas empanadas", -1)]
        public void EditRecipeInvalidInt_Test(string name, string description, int portions)
        {
            Assert.Throws<InvalidRequestException>(() => _useCase.EditRecipe(1, new RecipeRequest
            {
                Name = name,
                Description = description,
                Ingredients = new List<IngredientRequest>() { new IngredientRequest { IngredientId = 1 } },
                Portions = portions,
                Image = "",
                Steps = new List<StepRequest>() { new StepRequest { Step = "Cocinar" } }
            }));
        }
    }
}
