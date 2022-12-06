using CA.Recipe.Application.Exceptions;
using CA.Recipe.Application.Services;
using CA.Recipe.InterfacesAdapters.Data.Recipe;
using CA.Recipe.InterfacesAdapters.Gateway;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CA.Recipe.InterfacesAdapters.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
        public IHttpActionResult GetRecipes()
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
        public IHttpActionResult GetRecipeById(int id)
        {
            try
            {
                var response = _service.GetRecipe(id);

                return Content(HttpStatusCode.OK, response);
            }
            catch (EntityNotFoundException e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}