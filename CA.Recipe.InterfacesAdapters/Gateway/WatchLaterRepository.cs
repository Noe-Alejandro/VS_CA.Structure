using CA.Recipe.Application.Exceptions;
using CA.Recipe.Application.Interfaces;
using CA.Recipe.Application.Services.Port;
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

        public List<RecipeCoverResponse> ListWatchLater(int userId)
        {
            var list = _uowRecipe.WatchLaterRepository.Get(x => x.UserId.Equals(userId));
            var response = new List<RecipeCoverResponse>();
            if (list == null)
                return response;
            foreach (var recipe in list)
            {
                response.Add(new RecipeCoverResponse
                {
                    RecipeId = recipe.RecipeId,
                    Title = recipe.Recipe.Title,
                    Description = recipe.Recipe.Description,
                    ImageUrl = recipe.Recipe.ImageUrl,
                    Score = GetScore(recipe.Recipe.Score.ToList())
                });
            }
            return response;
        }

        private float GetScore(List<Score> scores)
        {
            int finalScore = 0;
            if (scores.Count == 0)
                return 0;
            foreach (var score in scores)
            {
                finalScore += score.Score1;
            }
            return (float)(Math.Truncate((double)((double)finalScore / (double)scores.Count) * 100.0) / 100.0);
        }
    }
}