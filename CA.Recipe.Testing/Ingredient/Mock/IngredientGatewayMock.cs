using CA.Recipe.Application.Interfaces;
using CA.Recipe.Application.Services.Port;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Recipe.Testing.Ingredient.Mock
{
    public class IngredientGatewayMock : IIngredientGateway
    {
        public List<IngredientResponseDB> GetAll()
        {
            return ingredients;
        }

        public static List<IngredientResponseDB> ingredients = new List<IngredientResponseDB>()
        {
            new IngredientResponseDB(){ id = 1, Name = "Tomate"},
            new IngredientResponseDB(){ id = 2, Name = "Cebolla"},
            new IngredientResponseDB(){ id = 3, Name = "Ajo"}
        };
    }
}
