using CA.Recipe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Recipe.Application.Services
{
    public class SearcherService
    {
        private IRecipeGateway _iRecipeGateway;
        public SearcherService(IRecipeGateway iRecipeGateway)
        {
            _iRecipeGateway = iRecipeGateway;
        }

        public void SearchRecipeByTitle()
        {
            _iRecipeGateway.FindByTitle();
            return;
        }

        public void SearchRecipeByIngredients()
        {
            _iRecipeGateway.FindByIngredients();
            return;
        }
    }
}
