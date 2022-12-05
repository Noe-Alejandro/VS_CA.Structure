using CA.Recipe.Application.Services;
using CA.Recipe.Application.Services.Port;
using CA.Recipe.InterfacesAdapters.Data.Recipe;
using CA.Recipe.InterfacesAdapters.Gateway;
using System;
using System.Net;
using System.Web.Http;

namespace CA.Recipe.InterfacesAdapters.Controllers
{
    public class RaterController : ApiController
    {
        private RaterService _service;
        public RaterController()
        {
            var uowRecipe = new UoWRecipe();
            _service = new RaterService(new ScoreRepository(uowRecipe));
        }

        [HttpPost]
        [Route("~/api/Rater")]
        public IHttpActionResult GiveAScore(ScoreRequest request)
        {
            try
            {
                _service.GiveAScore(request.recipeId, request.userId, request.score);

                return Ok();
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}