using CA.Recipe.Application.Services;
using CA.Recipe.Application.Services.Port;
using CA.Recipe.InterfacesAdapters.Data.Recipe;
using CA.Recipe.InterfacesAdapters.Gateway;
using System;
using System.Net;
using System.Web.Http;

namespace CA.Recipe.InterfacesAdapters.Controllers
{
    public class WriterController : ApiController
    {
        private WriterService _service;
        public WriterController()
        {
            var uowRecipe = new UoWRecipe();
            _service = new WriterService(new RecipeRepository(uowRecipe));
        }

        [HttpPost]
        [Route("~/api/Writer")]
        public IHttpActionResult CreateRecipe(RecipeRequest request)
        {
            try
            {
                var response = _service.CreateRecipe(request);

                return Content(HttpStatusCode.Created, response);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Route("~/api/Writer/{id}")]
        public IHttpActionResult UpdateRecipe(int id, [FromBody]RecipeRequest request)
        {
            try
            {
                _service.EditRecipe(id, request);

                return Ok();
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}