using CA.Recipe.Application.Services.Port;
using System.Collections.Generic;

namespace CA.Recipe.Application.Interfaces
{
    public interface IIngredientGateway
    {
        List<IngredientResponseDB> GetAll();
    }
}
