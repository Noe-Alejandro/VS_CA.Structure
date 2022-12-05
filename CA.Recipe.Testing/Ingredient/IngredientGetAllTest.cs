using CA.Recipe.Application.Services;
using CA.Recipe.Application.Services.Port;
using CA.Recipe.Testing.Ingredient.Mock;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Recipe.Testing.Ingredient
{
    public class IngredientGetAllTest
    {
        private IngredientService _useCase;
        [SetUp]
        public void Setup()
        {
            _useCase = new IngredientService(new IngredientGatewayMock());
        }

        [Test]
        public void GetAllIngredients_Test()
        {
            var ingredients = IngredientGatewayMock.ingredients;
            List<IngredientResponse> expectedObject = new List<IngredientResponse>();
            foreach (var ingredient in ingredients)
            {
                expectedObject.Add(new IngredientResponse
                {
                    IngredientId = ingredient.id,
                    Name = ingredient.Name
                });
            };
            var expectedValue = JsonConvert.SerializeObject(expectedObject);
            Assert.AreEqual(expectedValue, JsonConvert.SerializeObject(_useCase.GetAllIngredients()));
        }
    }
}
