using CA.Recipe.Application.Interfaces;
using CA.Recipe.InterfacesAdapters.Data.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CA.Recipe.InterfacesAdapters.Gateway
{
    public class ScoreRepository : IScoreGateway
    {
        private readonly UoWRecipe _uowRecipe;
        public ScoreRepository(UoWRecipe uowRecipe)
        {
            _uowRecipe = uowRecipe;
        }

        public void SetScore(int recipeId, int userId, int score)
        {
            var scoreExist = _uowRecipe.ScoreRepository.Get(x => x.UserId.Equals(userId) && x.RecipeId.Equals(recipeId)).FirstOrDefault();
            if (scoreExist == null)
            {
                _uowRecipe.ScoreRepository.Insert(new Score { UserId = userId, RecipeId = recipeId, Score1 = score });
            }
            else
            {
                scoreExist.Score1 = score;
            }
            _uowRecipe.Save();
        }
    }
}