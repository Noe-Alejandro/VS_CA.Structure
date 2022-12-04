using CA.Recipe.Application.Exceptions;
using CA.Recipe.Application.Interfaces;

namespace CA.Recipe.Application.Services
{
    public class RaterService
    {
        private IScoreGateway _iScoreGateway;
        public RaterService(IScoreGateway iScoreGateway)
        {
            _iScoreGateway = iScoreGateway;
        }

        public void GiveAScore(int recipeId, int userId, int score)
        {
            if (recipeId <= 0)
                throw new InvalidRequestException("Ingrese un id de receta válido");
            if(userId <= 0)
                throw new InvalidRequestException("Ingrese un id de usuario válido");
            if (score < 0 || score > 5)
                throw new InvalidRequestException("El score debe ser [0-5] y entero");
            _iScoreGateway.SetScore(recipeId, userId, score);
        }
    }
}
