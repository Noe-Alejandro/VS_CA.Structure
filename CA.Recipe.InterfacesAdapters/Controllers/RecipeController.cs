using CA.Recipe.Application.Services;
using CA.Recipe.InterfacesAdapters.Data.Recipe;
using CA.Recipe.InterfacesAdapters.Gateway;
using System;
using System.Net;
using System.Web.Http;

namespace CA.Recipe.InterfacesAdapters.Controllers
{
    public class RecipeController : ApiController
    {
        private RecipeService _service;
        public RecipeController()
        {
            var uowRecipe = new UoWRecipe();
            _service = new RecipeService(new RecipeRepository(uowRecipe));
        }

        [HttpGet]
        [Route("~/api/Recipe")]
        public IHttpActionResult GetAllIngredient()
        {
            try
            {
                var response = _service.GetAllRecipe();

                return Content(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("~/api/Recipe/{id}")]
        public IHttpActionResult GetAllIngredient(int id)
        {
            try
            {
                var response = _service.GetRecipe(id);

                return Content(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}