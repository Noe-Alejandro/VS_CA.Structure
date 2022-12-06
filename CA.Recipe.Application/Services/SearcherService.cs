using CA.Recipe.Application.Exceptions;
using CA.Recipe.Application.Interfaces;
using CA.Recipe.Application.Services.Port;
using System.Collections.Generic;

namespace CA.Recipe.Application.Services
{
    public class SearcherService
    {
        private IRecipeGateway _iRecipeGateway;
        public SearcherService(IRecipeGateway iRecipeGateway)
        {
            _iRecipeGateway = iRecipeGateway;
        }

        public List<RecipeCoverResponse> SearchRecipeByTitle(string title)
        {
            if(title == null || title.Trim().Equals(""))
                throw new InvalidRequestException("Ingrese el título por el que desea buscar");
            return _iRecipeGateway.FindByTitle(title); ;
        }

        public List<RecipeCoverResponse> SearchRecipeByIngredients(List<int> ingredientIdLst)
        {
            if (ingredientIdLst == null || ingredientIdLst.Count == 0)
                throw new InvalidRequestException("Ingrese al menos un ingrediente");
            return _iRecipeGateway.FindByIngredients(ingredientIdLst);
        }
    }
}
