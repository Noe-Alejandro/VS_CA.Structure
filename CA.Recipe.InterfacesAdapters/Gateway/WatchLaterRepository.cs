using CA.Recipe.Application.Interfaces;
using CA.Recipe.InterfacesAdapters.Data.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            _uowRecipe.WatchLaterRepository.Insert(new WatchLater
            {
                UserId = userId,
                RecipeId = recipeId
            });
        }
    }
}