using CA.Recipe.Application.Exceptions;
using CA.Recipe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
