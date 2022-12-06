using CA.Recipe.Application.Exceptions;
using CA.Recipe.Application.Services;
using CA.Recipe.InterfacesAdapters.Data.Recipe;
using CA.Recipe.InterfacesAdapters.Gateway;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CA.Recipe.InterfacesAdapters.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SearcherController : ApiController
    {
        private SearcherService _service;
        public SearcherController()
        {
            var uowRecipe = new UoWRecipe();
            _service = new SearcherService(new RecipeRepository(uowRecipe));
        }

        [HttpGet]
        [Route("~/api/Searcher/")]
        public IHttpActionResult SearchByTitle(string title)
        {
            try
            {
                var response = _service.SearchRecipeByTitle(title);

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

        [HttpGet]
        [Route("~/api/Searcher/")]
        public IHttpActionResult SearchByIngredients([FromUri]List<int> ids)
        {
            try
            {
                var response = _service.SearchRecipeByIngredients(ids);

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
    }
}