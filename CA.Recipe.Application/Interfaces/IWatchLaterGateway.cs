using CA.Recipe.Application.Services.Port;
using System.Collections.Generic;

namespace CA.Recipe.Application.Interfaces
{
    public interface IWatchLaterGateway
    {
        void AddWatchLater(int userId, int recipeId);
        List<RecipeCoverResponse> ListWatchLater(int userId);
    }
}
