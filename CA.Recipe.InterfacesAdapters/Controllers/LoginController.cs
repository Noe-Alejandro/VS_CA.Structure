using CA.Recipe.Application.Services;
using CA.Recipe.Application.Services.Port;
using CA.Recipe.InterfacesAdapters.Data.Recipe;
using CA.Recipe.InterfacesAdapters.Gateway;
using System;
using System.Net;
using System.Web.Http;

namespace CA.Recipe.InterfacesAdapters.Controllers
{
    public class LoginController : ApiController
    {
        private LoginService _service;
        public LoginController()
        {
            var uowRecipe = new UoWRecipe();
            _service = new LoginService(new UserRepository(uowRecipe));
        }

        [HttpPost]
        [Route("~/api/Login")]
        public IHttpActionResult CreateRecipe(UserRequest request)
        {
            try
            {
                var response = _service.LoginUser(request);

                return Content(HttpStatusCode.Created, response);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}