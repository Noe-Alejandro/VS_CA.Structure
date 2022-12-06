using CA.Recipe.Application.Exceptions;
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
            var watchLaterExist = _uowRecipe.WatchLaterRepository.Get(x => x.UserId.Equals(userId) && x.RecipeId.Equals(recipeId)).FirstOrDefault();
            if (watchLaterExist != null)
                throw new AlreadyAddedException("Ya se encuentra en tus ver más tarde");
            _uowRecipe.WatchLaterRepository.Insert(new WatchLater
            {
                UserId = userId,
                RecipeId = recipeId
            });
            _uowRecipe.Save();
        }
    }
}