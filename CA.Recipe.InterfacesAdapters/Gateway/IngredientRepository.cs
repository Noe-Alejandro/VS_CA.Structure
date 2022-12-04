using CA.Recipe.Application.Interfaces;
using CA.Recipe.Application.Services.Port;
using CA.Recipe.InterfacesAdapters.Data.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CA.Recipe.InterfacesAdapters.Gateway
{
    public class IngredientRepository : IIngredientGateway
    {
        private readonly UoWRecipe _uowRecipe;
        public IngredientRepository(UoWRecipe uowRecipe)
        {
            _uowRecipe = uowRecipe;
        }

        public List<IngredientResponseDB> GetAll()
        {
            var lstEntities = _uowRecipe.IngredientRepository.GetAll().ToList();
            var response = new List<IngredientResponseDB>();
            foreach (var entities in lstEntities) {
                response.Add(new IngredientResponseDB
                {
                    id = entities.IngredientId,
                    Name = entities.Name
                });
            }
            return response;
        }
    }
}