using CA.Recipe.Application.Services;
using CA.Recipe.FrameworksDrivers;
using CA.Recipe.InterfacesAdapters.Gateway;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CA.Recipe.InterfacesAdapters.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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

                return Content(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}