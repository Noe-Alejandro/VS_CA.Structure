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

        public RecipeResponse GetRecipe(int id)
        {
            var gatewayResponse = _iRecipeGateway.GetRecipe(id);
            return new RecipeResponse
            {
                Id = gatewayResponse.Id,
                Name = gatewayResponse.Name
            };
        }

        public List<RecipeResponse> GetAllRecipe()
        {
            List<RecipeResponse> lstRecipe = new List<RecipeResponse>();
            var gatewayResponse = _iRecipeGateway.GetAllRecipe();
            for (var i = 0; i<gatewayResponse.Count; i++)
            {
                lstRecipe.Add(new RecipeResponse
                {
                    Id = gatewayResponse[i].Id,
                    Name = gatewayResponse[i].Name
                });
            }
            return lstRecipe;
        }
    }
}
