using CA.Recipe.Application.Exceptions;
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
                Name = recipe.Name
            };
        }

        public List<RecipeCoverResponse> GetAllRecipe()
        {
            return new List<RecipeCoverResponse>(){ 
                new RecipeCoverResponse
                {
                    RecipeId = 1,
                    Title = "Prueba",
                    Description = "Prueba",
                    Score = 5.00f
                }
            };
        }

        public RecipeDetailResponse GetRecipe(int id)
        {
            if (id <= 0)
                throw new InvalidRequestException("El id de la recta no es válido");
            if (id != 1)
                throw new EntityNotFoundException($"La recta con id {id} no se encontró");
            return new RecipeDetailResponse
            {
                RecipeId = 1,
                Title = "Prueba",
                Description = "Prueba",
                Ingredients = new List<IngredientAmount>() { new IngredientAmount { Name = "Cebolla", Amount = 1 } },
                Score = 5.00f
            };
        }

        public void FindByTitle()
        {
            throw new System.NotImplementedException();
        }

        public void FindByIngredients()
        {
            throw new System.NotImplementedException();
        }

        public RecipeResponseDB UpdateRecipe(int recipeId, RecipeRequest request)
        {
            if (recipeId != 1)
                return null;
            return new RecipeResponseDB
            {
                Id = 1,
                Name = request.Name
            };
        }
    }
}
