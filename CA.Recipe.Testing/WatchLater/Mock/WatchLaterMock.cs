using CA.Recipe.Application.Exceptions;
using CA.Recipe.Application.Interfaces;
using CA.Recipe.Application.Services.Port;
using System;
using System.Collections.Generic;

namespace CA.Recipe.Testing.WatchLater.Mock
{
    public class WatchLaterMock : IWatchLaterGateway
    {
        public void AddWatchLater(int userId, int recipeId)
        {
            if (userId.Equals(1) && recipeId.Equals(26))
                throw new AlreadyAddedException("La receta ya se encuentra agregada");
            return;
        }

        public List<RecipeCoverResponse> ListWatchLater(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
