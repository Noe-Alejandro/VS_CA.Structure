using CA.Recipe.Application.Exceptions;
using CA.Recipe.Application.Services;
using CA.Recipe.Application.Services.Port;
using CA.Recipe.Testing.Recipe.Mock;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using static CA.Recipe.Testing.Recipe.Mock.RecipeGatewayMock;

namespace CA.Recipe.Testing.Searcher
{
    public class SearcherFindByTitleTest
    {
        private SearcherService _useCase;
        [SetUp]
        public void Setup()
        {
            _useCase = new SearcherService(new RecipeGatewayMock());
        }

        [TestCase("Prueba2")]
        public void FindByTitleExactly_Test(string title)
        {
            var mockObject = new List<RecipeResponseDBV2>() { recipeDB[1] };
            List<RecipeCoverResponse> expectedObject = new List<RecipeCoverResponse>();
            foreach (var item in mockObject)
            {
                expectedObject.Add(new RecipeCoverResponse
                {
                    RecipeId = item.Id,
                    Description = item.Description,
                    Title = item.Name,
                    ImageUrl = item.ImageUrl,
                    Score = item.Score
                });
            }
            var expectedValue = JsonConvert.SerializeObject(expectedObject);
            Assert.AreEqual(expectedValue, JsonConvert.SerializeObject(_useCase.SearchRecipeByTitle(title)));
        }

        [TestCase("Prueba")]
        public void FindByTitleCoincidence_Test(string title)
        {
            var mockObject = new List<RecipeResponseDBV2>() { recipeDB[0], recipeDB[1], recipeDB[2] };
            List<RecipeCoverResponse> expectedObject = new List<RecipeCoverResponse>();
            foreach (var item in mockObject)
            {
                expectedObject.Add(new RecipeCoverResponse
                {
                    RecipeId = item.Id,
                    Description = item.Description,
                    Title = item.Name,
                    ImageUrl = item.ImageUrl,
                    Score = item.Score
                });
            }
            var expectedValue = JsonConvert.SerializeObject(expectedObject);
            Assert.AreEqual(expectedValue, JsonConvert.SerializeObject(_useCase.SearchRecipeByTitle(title)));
        }

        [TestCase("")]
        public void FindByTitleInvalidTitle_Test(string title)
        {
            Assert.Throws<InvalidRequestException>(() => _useCase.SearchRecipeByTitle(title));
        }

        private static List<RecipeResponseDBV2> recipeDB = new List<RecipeResponseDBV2>()
        {
            new RecipeResponseDBV2(){ Id = 1, Description = "Prueba", Name = "Prueba", Score = 5.0f, ImageUrl = "url", Ingredients = ingredientItem1},
            new RecipeResponseDBV2(){ Id = 2, Description = "Prueba2", Name = "Prueba2", Score = 4.5f, ImageUrl = "url", Ingredients = ingredientItem2},
            new RecipeResponseDBV2(){ Id = 3, Description = "Prueba3", Name = "Prueba3", Score = 3.0f, ImageUrl = "url", Ingredients = ingredientItem1}
        };

        private static List<IngredientAmountDB> ingredientItem1 = new List<IngredientAmountDB>()
        {
            new IngredientAmountDB(){ Id = 1, Name = "Tomate", Amount = 1},
            new IngredientAmountDB(){ Id = 2, Name = "Cebolla", Amount = 1}
        };

        private static List<IngredientAmountDB> ingredientItem2 = new List<IngredientAmountDB>()
        {
            new IngredientAmountDB(){ Id = 1, Name = "Tomate", Amount = 1},
            new IngredientAmountDB(){ Id = 3, Name = "Ajo", Amount = 1}
        };
    }
}
