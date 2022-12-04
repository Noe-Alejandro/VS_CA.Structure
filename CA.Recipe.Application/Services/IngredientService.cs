using CA.Recipe.Application.Interfaces;
using CA.Recipe.Application.Services.Port;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Recipe.Application.Services
{
    public class IngredientService
    {
        private IIngredientGateway _iIngredientGateway;
        public IngredientService(IIngredientGateway iIngredientGateway)
        {
            _iIngredientGateway = iIngredientGateway;
        }

        public List<IngredientResponse> GetAllIngredients()
        {
            List<IngredientResponseDB> responseGateway = _iIngredientGateway.GetAll();
            List<IngredientResponse> response = new List<IngredientResponse>();
            foreach (var ingredient in responseGateway)
            {
                response.Add(new IngredientResponse
                {
                    IngredientId = ingredient.id,
                    Name = ingredient.Name
                });
            }
            return response;
        }
    }
}
