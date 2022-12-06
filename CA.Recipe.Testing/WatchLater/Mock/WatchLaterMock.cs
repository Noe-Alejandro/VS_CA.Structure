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
            if (userId >= 100)
                throw new EntityNotFoundException("No se encontró el id del usuario");
            return new List<RecipeCoverResponse>()
            {
                new RecipeCoverResponse { RecipeId = 1, Title = "Prueba", Description = "Prueba", ImageUrl = "url", Score = 5.00f, Author = "noeshi" },
                new RecipeCoverResponse { RecipeId = 2, Title = "Prueba 2", Description = "Prueba 2", ImageUrl = "url2", Score = 4.50f, Author = "pastito" }
            };
        }
    }
}
