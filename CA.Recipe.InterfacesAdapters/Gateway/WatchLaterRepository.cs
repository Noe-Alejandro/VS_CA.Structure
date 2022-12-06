using CA.Recipe.Application.Exceptions;
using CA.Recipe.Application.Interfaces;
using CA.Recipe.Application.Services.Port;
using CA.Recipe.FrameworksDrivers;
using CA.Recipe.FrameworksDrivers.Data.Recipe;
using CA.Recipe.InterfacesAdapters.Helper;
using System.Collections.Generic;
using System.Linq;

namespace CA.Recipe.InterfacesAdapters.Gateway
{
    public class WatchLaterRepository : IWatchLaterGateway
    {
        private readonly UoWRecipe _uowRecipe;
        public WatchLaterRepository(UoWRecipe uowRecipe)
        {
            _uowRecipe = uowRecipe;
        }

        public void AddWatchLater(int userId, int recipeId)
        {
            var watchLaterExist = _uowRecipe.WatchLaterRepository.Get(x => x.UserId.Equals(userId) && x.RecipeId.Equals(recipeId)).FirstOrDefault();
            if (watchLaterExist != null)
                throw new AlreadyAddedException("Ya se encuentra en tus ver más tarde");
            _uowRecipe.WatchLaterRepository.Insert(new WatchLater { UserId = userId, RecipeId = recipeId });
            _uowRecipe.Save();
        }

        public List<RecipeCoverResponse> ListWatchLater(int userId)
        {
            var list = _uowRecipe.WatchLaterRepository.Get(x => x.UserId.Equals(userId));
            if (list == null)
                return new List<RecipeCoverResponse>();
            return MapperHelperInfra.Map<List<RecipeCoverResponse>>(list);
        }
    }
}