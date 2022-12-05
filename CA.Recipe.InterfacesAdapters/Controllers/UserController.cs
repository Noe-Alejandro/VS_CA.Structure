using CA.Recipe.Application.Exceptions;
using CA.Recipe.Application.Services;
using CA.Recipe.Application.Services.Port;
using CA.Recipe.InterfacesAdapters.Data.Recipe;
using CA.Recipe.InterfacesAdapters.Gateway;
using System;
using System.Net;
using System.Web.Http;

namespace CA.Recipe.InterfacesAdapters.Controllers
{
    public class UserController : ApiController
    {
        private UserService _service;
        public UserController()
        {
            var uowRecipe = new UoWRecipe();
            _service = new UserService(new UserRepository(uowRecipe), new WatchLaterRepository(uowRecipe));
        }

        [HttpPost]
        [Route("~/api/User/Register")]
        public IHttpActionResult GetAllIngredient(UserRequest request)
        {
            try
            {
                var response = _service.RegisterUser(request);

                return Content(HttpStatusCode.Created, response);
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