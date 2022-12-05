using CA.Recipe.Application.Exceptions;
using CA.Recipe.Application.Services;
using CA.Recipe.Application.Services.Port;
using CA.Recipe.InterfacesAdapters.Data.Recipe;
using CA.Recipe.InterfacesAdapters.Gateway;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CA.Recipe.InterfacesAdapters.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
        public IHttpActionResult RegisterUser(UserRequest request)
        {
            try
            {
                var response = _service.RegisterUser(request);

                return Content(HttpStatusCode.Created, response);
            }
            catch (AlreadyAddedException e)
            {
                return Content(HttpStatusCode.Forbidden, e.Message);
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

        [HttpPost]
        [Route("~/api/User/WatchLater")]
        public IHttpActionResult AddWatchLater(WatchLaterRequest request)
        {
            try
            {
                _service.AddWatchLater(request.userId, request.recipeId);

                return Content(HttpStatusCode.Created, "Created");
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

        [HttpGet]
        [Route("~/api/User/{id}")]
        public IHttpActionResult GetUser(int id)
        {
            try
            {
                var response = _service.GetUser(id);

                return Content(HttpStatusCode.OK, response);
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

        [HttpPut]
        [Route("~/api/User/{id}")]
        public IHttpActionResult UpdateUser(int id, UserEditRequest request)
        {
            try
            {
                _service.EditUser(id, request);

                return Ok();
            }
            catch (InvalidRequestException e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
            catch (EmailInUseException e)
            {
                return Content(HttpStatusCode.Forbidden, e.Message);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}