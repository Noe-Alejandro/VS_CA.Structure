using CA.Recipe.Application.Exceptions;
using CA.Recipe.Application.Interfaces;
using CA.Recipe.Application.Services.Port;
using System;

namespace CA.Recipe.Application.Services
{
    public class WriterService
    {
        private IRecipeGateway _iRecipeGateway;
        public WriterService(IRecipeGateway iRecipeGateway)
        {
            _iRecipeGateway = iRecipeGateway;
        }

        public RecipeResponse CreateRecipe(RecipeRequest request)
        {
            ValidateRequest(request);
            RecipeResponseDB gatewayResponse = _iRecipeGateway.InsertRecipe(request);
            return new RecipeResponse
            {
                Id = gatewayResponse.Id,
                Name = gatewayResponse.Name
            };
        }

        public bool EditRecipe(int recipeId, RecipeRequest request)
        {
            RecipeResponseDB gatewayResponse = _iRecipeGateway.UpdateRecipe(recipeId, request);
            if (gatewayResponse == null)
                throw new EntityNotFoundException($"No se encontró la receta con el id {recipeId}");
            ValidateRequest(request);
            _iRecipeGateway.UpdateRecipe(recipeId, request);
            return true;
        }

        private void ValidateRequest(RecipeRequest request)
        {
            if (request.Name == null || request.Name.Trim().Equals(""))
                throw new InvalidRequestException("Ingrese un valor válido en Name");
            if (request.Description == null || request.Description.Trim().Equals(""))
                throw new InvalidRequestException("Ingrese un valor válido en Description");
            if (request.Portions <= 0)
                throw new InvalidRequestException("Ingrese un valor válido para el número de porciones");
            if (request.Ingredients == null || request.Ingredients.Count == 0)
                throw new InvalidRequestException("Ingrese los ingredientes de la receta");
            if (request.Steps == null || request.Steps.Trim().Equals(""))
                throw new InvalidRequestException("Ingrese los pasos de la receta");
        }
    }
}
