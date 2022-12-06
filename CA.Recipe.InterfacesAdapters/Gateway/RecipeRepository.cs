using CA.Recipe.Application.Exceptions;
using CA.Recipe.Application.Interfaces;
using CA.Recipe.Application.Services.Port;
using CA.Recipe.FrameworksDrivers;
using CA.Recipe.FrameworksDrivers.Data.Recipe;
using CA.Recipe.InterfacesAdapters.Helper;
using System.Collections.Generic;
using System.Linq;

namespace CA.Recipe.InterfacesAdapters.Gateway
{
    public class RecipeRepository : IRecipeGateway
    {
        private readonly UoWRecipe _uowRecipe;
        public RecipeRepository(UoWRecipe uowRecipe)
        {
            _uowRecipe = uowRecipe;
        }

        public List<RecipeCoverResponse> FindByIngredients(List<int> ingredientIdLst)
        {
            var all = _uowRecipe.RecipeRepository.GetAll().ToList();
            var recipes = all.FindAll(x => x.Amount.ToList().FindAll(y => ingredientIdLst.Contains(y.IngredientId)).Count >= ingredientIdLst.Count);
            if (recipes == null)
                return new List<RecipeCoverResponse>();
            return MapperHelperInfra.Map<List<RecipeCoverResponse>>(recipes);
        }

        public List<RecipeCoverResponse> FindByTitle(string title)
        {
            var recipes = _uowRecipe.RecipeRepository.Get(x => x.Title.Contains(title)).ToList();
            if (recipes == null)
                return new List<RecipeCoverResponse>();
            return MapperHelperInfra.Map<List<RecipeCoverResponse>>(recipes);
        }

        public List<RecipeCoverResponse> GetAllRecipe()
        {
            return MapperHelperInfra.Map<List<RecipeCoverResponse>>(_uowRecipe.RecipeRepository.GetAll().ToList());
        }

        public RecipeDetailResponse GetRecipe(int id)
        {
            var recipe = _uowRecipe.RecipeRepository.GetByID(id);
            if (recipe == null)
                throw new EntityNotFoundException("El id de la recta no existe en la base de datos");
            return MapperHelperInfra.Map<RecipeDetailResponse>(recipe);
        }

        public RecipeResponseDB InsertRecipe(RecipeRequest recipe)
        {
            var newRecipe = MapperHelperInfra.Map<FrameworksDrivers.Data.Recipe.Recipe>(recipe);
            _uowRecipe.RecipeRepository.Insert(newRecipe);
            _uowRecipe.Save();
            return new RecipeResponseDB { Id = newRecipe.RecipeId };
        }

        public RecipeResponseDB UpdateRecipe(int recipeId, RecipeRequest request)
        {
            var recipe = _uowRecipe.RecipeRepository.GetByID(recipeId);
            if (recipe == null)
                throw new EntityNotFoundException($"No se encontró la receta con id {recipeId}");
            recipe.Title = request.Name;
            recipe.Description = request.Description;
            recipe.Step = request.Steps;
            recipe.ImageUrl = request.Image;
            recipe.Portion = request.Portions;

            var ingredients = new List<Amount>();
            foreach (var ingredient in request.Ingredients)
            {
                ingredients.Add(new Amount
                {
                    Amount1 = ingredient.Amount,
                    IngredientId = ingredient.IngredientId,
                    RecipeId = recipeId
                });
            }
            _uowRecipe.AmountRepository.DeleteByRange(recipe.Amount.ToList());
            _uowRecipe.AmountRepository.InsertByRange(ingredients);
            _uowRecipe.Save();
            return null;
        }
    }
}