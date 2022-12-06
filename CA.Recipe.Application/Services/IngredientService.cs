using CA.Recipe.Application.Helpers;
using CA.Recipe.Application.Interfaces;
using CA.Recipe.Application.Services.Port;
using System.Collections.Generic;

namespace CA.Recipe.Application.Services
{
    public class IngredientService
    {
        private IIngredientGateway _iIngredientGateway;
        public IngredientService(IIngredientGateway iIngredientGateway)
        {
            _iIngredientGateway = iIngredientGateway;
        }

        public List<IngredientResponse> GetAllIngredients()
        {
            return MapperHelper.Map<List<IngredientResponse>>(_iIngredientGateway.GetAll());
        }
    }
}
