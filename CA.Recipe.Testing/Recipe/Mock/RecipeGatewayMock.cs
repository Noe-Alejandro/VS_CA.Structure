using CA.Recipe.Application.Interfaces;
using CA.Recipe.Application.Services.Port;
using System.Collections.Generic;

namespace CA.Recipe.Testing.Recipe.Mock
{
    public class RecipeGatewayMock : IRecipeGateway
    {
        public RecipeResponseDB InsertRecipe(RecipeRequest recipe)
        {
            return new RecipeResponseDB
            {
                Id = 1,
                Name = "Prueba",
                Author = "Prueba"
            };
        }

        public List<RecipeResponseDB> GetAllRecipe()
        {
            return new List<RecipeResponseDB>()
            {
                new RecipeResponseDB { Id = 1, Name = "Prueba", Author = "Prueba" }
            };
        }

        public RecipeResponseDB GetRecipe(int id)
        {
            return new RecipeResponseDB { Id = 1, Name = "Prueba", Author = "Prueba" };
        }

        public void UpdateRecipe()
        {
            throw new System.NotImplementedException();
        }

        public void FindByTitle()
        {
            throw new System.NotImplementedException();
        }

        public void FindByIngredients()
        {
            throw new System.NotImplementedException();
        }
    }
}
