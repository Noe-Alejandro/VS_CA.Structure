using CA.Recipe.Application.Interfaces;
using CA.Recipe.Application.Services.Port;
using System.Collections.Generic;

namespace CA.Recipe.Application.Services
{
    public class RecipeService
    {
        private IRecipeGateway _iRecipeGateway;
        public RecipeService(IRecipeGateway iRecipeGateway)
        {
            _iRecipeGateway = iRecipeGateway;
        }

        public RecipeDetailResponse GetRecipe(int id)
        {
            var gatewayResponse = _iRecipeGateway.GetRecipe(id);
            return new RecipeDetailResponse
            {
                RecipeId = gatewayResponse.RecipeId,
                Title = gatewayResponse.Title,
                Description = gatewayResponse.Description,
                Ingredients = gatewayResponse.Ingredients,
                Portions = 1,
                Steps = gatewayResponse.Steps,
                Score = gatewayResponse.Score,
                Author = gatewayResponse.Author
            };
        }

        public List<RecipeCoverResponse> GetAllRecipe()
        {
            List<RecipeCoverResponse> lstRecipe = new List<RecipeCoverResponse>();
            var gatewayResponse = _iRecipeGateway.GetAllRecipe();
            for (var i = 0; i<gatewayResponse.Count; i++)
            {
                lstRecipe.Add(new RecipeCoverResponse
                {
                    RecipeId = gatewayResponse[i].RecipeId,
                    Title = gatewayResponse[i].Title,
                    Description = gatewayResponse[i].Description,
                    ImageUrl = gatewayResponse[i].ImageUrl,
                    Score = gatewayResponse[i].Score
                });
            }
            return lstRecipe;
        }
    }
}
