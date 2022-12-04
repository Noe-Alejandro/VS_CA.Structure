using CA.Recipe.Application.Services;
using CA.Recipe.InterfacesAdapters.Data.Recipe;
using CA.Recipe.InterfacesAdapters.Gateway;
using System;
using System.Net;
using System.Web.Http;

namespace CA.Recipe.InterfacesAdapters.Controllers
{
    public class IngredientController : ApiController
    {
        private IngredientService _service;
        public IngredientController()
        {
            _service = new IngredientService(new IngredientRepository(new UoWRecipe()));
        }

        [HttpGet]
        [Route("~/api/Ingredient")]
        public IHttpActionResult GetAllIngredient()
        {
            try
            {
                var response = _service.GetAllIngredients();

                if (response != null)
                    return Content(HttpStatusCode.OK, response);

                return BadRequest();
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}