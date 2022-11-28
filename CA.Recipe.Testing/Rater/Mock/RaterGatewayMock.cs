using CA.Recipe.Application.Interfaces;
using System;

namespace CA.Recipe.Testing.Rater.Mock
{
    public class RaterGatewayMock : IScoreGateway
    {
        public void SetScore(int recipeId, int userId, int score)
        {
            if (recipeId != 1)
                throw new Exception($"No se encontró la receta con id {recipeId}");
            if (userId != 1)
                throw new Exception($"No se encontró el user con id {userId}");
            return;
        }
    }
}
