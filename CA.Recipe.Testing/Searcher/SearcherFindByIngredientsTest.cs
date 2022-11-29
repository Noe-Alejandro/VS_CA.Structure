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
    public class SearcherFindByIngredientsTest
    {
        private SearcherService _useCase;
        [SetUp]
        public void Setup()
        {
            _useCase = new SearcherService(new RecipeGatewayMock());
        }

        [TestCase(3)]
        public void FindByIngredientsExactly_Test(int id1)
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
                    Score = item.Score
                });
            }
            var expectedValue = JsonConvert.SerializeObject(expectedObject);
            Assert.AreEqual(expectedValue, JsonConvert.SerializeObject(_useCase.SearchRecipeByIngredients(new List<int>() { id1 })));
        }

        [TestCase(2,3)]
        public void FindByIngredientsCoincidence_Test(int id1, int id2)
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
                    Score = item.Score
                });
            }
            var expectedValue = JsonConvert.SerializeObject(expectedObject);
            Assert.AreEqual(expectedValue, JsonConvert.SerializeObject(_useCase.SearchRecipeByIngredients(new List<int>() { id1, id2})));
        }

        [TestCase(0)]
        public void FindByIngredientsInvalidId_Test(int id)
        {
            Assert.Throws<InvalidRequestException>(() => _useCase.SearchRecipeByIngredients(new List<int>() { id }));
        }

        private static List<RecipeResponseDBV2> recipeDB = new List<RecipeResponseDBV2>()
        {
            new RecipeResponseDBV2(){ Id = 1, Description = "Prueba", Name = "Prueba", Score = 5.0f, Ingredients =  new List<IngredientAmountDB>()
                {
                    new IngredientAmountDB(){ Id = 1, Name = "Tomate", Amount = 1},
                    new IngredientAmountDB(){ Id = 2, Name = "Cebolla", Amount = 1}
                }},
            new RecipeResponseDBV2(){ Id = 2, Description = "Prueba2", Name = "Prueba2", Score = 4.5f, Ingredients =  new List<IngredientAmountDB>()
                {
                    new IngredientAmountDB(){ Id = 1, Name = "Tomate", Amount = 1},
                    new IngredientAmountDB(){ Id = 3, Name = "Ajo", Amount = 1}
                }},
            new RecipeResponseDBV2(){ Id = 3, Description = "Prueba3", Name = "Prueba3", Score = 3.0f, Ingredients =  new List<IngredientAmountDB>()
                {
                    new IngredientAmountDB(){ Id = 1, Name = "Tomate", Amount = 1},
                    new IngredientAmountDB(){ Id = 2, Name = "Cebolla", Amount = 1}
                }}
        };
    }
}
