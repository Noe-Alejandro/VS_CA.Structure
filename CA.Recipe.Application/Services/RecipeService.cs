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
            return _iRecipeGateway.GetRecipe(id);
        }

        public List<RecipeCoverResponse> GetAllRecipe()
        {
            return _iRecipeGateway.GetAllRecipe();
        }
    }
}
