using CA.Recipe.Application.Interfaces;
using CA.Recipe.Application.Services.Port;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Recipe.Application.Services
{
    public class WriterService
    {
        private IRecipeGateway _iRecipeGateway;
        public WriterService(IRecipeGateway iRecipeGateway)
        {
            _iRecipeGateway = iRecipeGateway;
        }

        public void CreateRecipe()
        {
            _iRecipeGateway.InsertRecipe(new RecipeRequest());
            return;
        }

        public void EditRecipe()
        {
            _iRecipeGateway.UpdateRecipe();
            return;
        }
    }
}
