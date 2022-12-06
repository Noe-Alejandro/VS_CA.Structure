using CA.Recipe.Application.Exceptions;
using CA.Recipe.Application.Services;
using CA.Recipe.Application.Services.Port;
using CA.Recipe.FrameworksDrivers;
using CA.Recipe.InterfacesAdapters.Gateway;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CA.Recipe.InterfacesAdapters.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
            catch (InvalidRequestException e)
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