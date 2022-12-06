using CA.Recipe.Application.Interfaces;
using CA.Recipe.Application.Services.Port;
using CA.Recipe.FrameworksDrivers;
using CA.Recipe.InterfacesAdapters.Helper;
using System.Collections.Generic;
using System.Linq;

namespace CA.Recipe.InterfacesAdapters.Gateway
{
    public class IngredientRepository : IIngredientGateway
    {
        private readonly UoWRecipe _uowRecipe;
        public IngredientRepository(UoWRecipe uowRecipe)
        {
            _uowRecipe = uowRecipe;
        }

        public List<IngredientResponseDB> GetAll()
        {
            return MapperHelperInfra.Map<List<IngredientResponseDB>>(_uowRecipe.IngredientRepository.GetAll().ToList());
        }
    }
}