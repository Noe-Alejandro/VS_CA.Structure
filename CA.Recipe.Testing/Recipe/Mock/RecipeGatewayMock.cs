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
                Id = 1
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
                    ImageUrl = "url",
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
                ImageUrl = "url",
                Ingredients = new List<IngredientAmount>() { new IngredientAmount { Name = "Cebolla", Amount = 1 } },
                Portions = 1,
                Steps = "Vivir",
                Score = 5.00f,
                Author = "patojuarez"
            };
        }

        public RecipeResponseDB UpdateRecipe(int recipeId, RecipeRequest request)
        {
            if (recipeId != 1)
                throw new EntityNotFoundException();
            return new RecipeResponseDB
            {
                Id = 1,
                Name = request.Name
            };
        }

        public List<RecipeCoverResponse> FindByTitle(string title)
        {
            var lst = recipeDB.FindAll(x => x.Name.Contains(title));
            List<RecipeCoverResponse> response = new List<RecipeCoverResponse>();
            foreach (var item in lst)
            {
                response.Add(new RecipeCoverResponse
                {
                    RecipeId = item.Id, Description = item.Description, Title = item.Name, Score = item.Score, ImageUrl = item.ImageUrl
                });
            }
            return response;
        }

        public List<RecipeCoverResponse> FindByIngredients(List<int> ingredientIdLst)
        {
            if (ingredientIdLst.FindAll(x => x <= 0).Count > 0)
                throw new InvalidRequestException("El id de uno o varios ingredientes no es válido");
            var lst = recipeDB.FindAll(x => x.Ingredients.FindAll(y => ingredientIdLst.Contains(y.Id)).Count > 0);
            List<RecipeCoverResponse> response = new List<RecipeCoverResponse>();
            foreach (var item in lst)
            {
                response.Add(new RecipeCoverResponse
                {
                    RecipeId = item.Id,
                    Description = item.Description,
                    Title = item.Name,
                    ImageUrl = item.ImageUrl,
                    Score = item.Score
                });
            }
            return response;
        }

        private static List<RecipeResponseDBV2> recipeDB = new List<RecipeResponseDBV2>()
        {
            new RecipeResponseDBV2(){ Id = 1, Description = "Prueba", Name = "Prueba", Score = 5.0f, ImageUrl = "url", Ingredients =  new List<IngredientAmountDB>()
                {
                    new IngredientAmountDB(){ Id = 1, Name = "Tomate", Amount = 1},
                    new IngredientAmountDB(){ Id = 2, Name = "Cebolla", Amount = 1}
                }},
            new RecipeResponseDBV2(){ Id = 2, Description = "Prueba2", Name = "Prueba2", Score = 4.5f, ImageUrl = "url", Ingredients =  new List<IngredientAmountDB>()
                {
                    new IngredientAmountDB(){ Id = 1, Name = "Tomate", Amount = 1},
                    new IngredientAmountDB(){ Id = 3, Name = "Ajo", Amount = 1}
                }},
            new RecipeResponseDBV2(){ Id = 3, Description = "Prueba3", Name = "Prueba3", Score = 3.0f, ImageUrl = "url", Ingredients =  new List<IngredientAmountDB>()
                {
                    new IngredientAmountDB(){ Id = 1, Name = "Tomate", Amount = 1},
                    new IngredientAmountDB(){ Id = 2, Name = "Cebolla", Amount = 1}
                }}
        };

        public class RecipeResponseDBV2
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public List<IngredientAmountDB> Ingredients { get; set; }
            public string ImageUrl { get; set; }

            public float Score { get; set; }
        }

        public class IngredientAmountDB
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Amount { get; set; }
        }
    }
}
