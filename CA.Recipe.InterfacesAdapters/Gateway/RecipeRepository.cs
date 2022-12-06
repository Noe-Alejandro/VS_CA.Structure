using CA.Recipe.Application.Exceptions;
using CA.Recipe.Application.Interfaces;
using CA.Recipe.Application.Services.Port;
using CA.Recipe.InterfacesAdapters.Data.Recipe;
using System;
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
            return MapRecipes(recipes);
        }

        public List<RecipeCoverResponse> FindByTitle(string title)
        {
            var recipes = _uowRecipe.RecipeRepository.Get(x => x.Title.Contains(title)).ToList();
            if (recipes == null)
                return new List<RecipeCoverResponse>();
            return MapRecipes(recipes);
        }

        public List<RecipeCoverResponse> GetAllRecipe()
        {
            var recipesDB = _uowRecipe.RecipeRepository.GetAll().ToList();
            return MapRecipes(recipesDB);
        }

        public RecipeDetailResponse GetRecipe(int id)
        {
            var recipe = _uowRecipe.RecipeRepository.GetByID(id);
            if (recipe == null)
                throw new EntityNotFoundException("El id de la recta no existe en la base de datos");
            return new RecipeDetailResponse
            {
                RecipeId = recipe.RecipeId,
                Title = recipe.Title,
                Description = recipe.Description,
                ImageUrl = recipe.ImageUrl,
                Portions = recipe.Portion,
                Steps = recipe.Step,
                Score = GetScore(recipe.Score.ToList()),
                Author = recipe.User.UserName,
                Ingredients = MapIngredients(recipe.Amount.ToList())
            };
        }

        public RecipeResponseDB InsertRecipe(RecipeRequest recipe)
        {
            var ingredients = new List<Amount>();
            foreach (var item in recipe.Ingredients)
            {
                ingredients.Add(new Amount
                {
                    Amount1 = item.Amount,
                    IngredientId = item.IngredientId
                });
            }
            var newRecipe = new Data.Recipe.Recipe
            {
                UserId = recipe.UserId,
                Title = recipe.Name,
                Description = recipe.Description,
                Amount = ingredients,
                Step = recipe.Steps,
                Portion = recipe.Portions,
                ImageUrl = recipe.Image
            };
            _uowRecipe.RecipeRepository.Insert(newRecipe);
            _uowRecipe.Save();
            return new RecipeResponseDB
            {
                Id = newRecipe.RecipeId,
            };
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

        private float GetScore(List<Score> scores)
        {
            int finalScore = 0;
            if (scores.Count == 0)
                return 0;
            foreach (var score in scores)
            {
                finalScore += score.Score1;
            }
            return (float)(Math.Truncate((double)((double)finalScore / (double)scores.Count) * 100.0) / 100.0);
        }

        private List<RecipeCoverResponse> MapRecipes(List<Data.Recipe.Recipe> recipesDB)
        {
            var response = new List<RecipeCoverResponse>();
            foreach (var recipe in recipesDB)
            {
                response.Add(new RecipeCoverResponse
                {
                    RecipeId = recipe.RecipeId,
                    Title = recipe.Title,
                    Description = recipe.Description,
                    ImageUrl = recipe.ImageUrl,
                    Score = GetScore(recipe.Score.ToList())
                });
            }
            return response;
        }

        private List<IngredientAmount> MapIngredients(List<Amount> ingredients)
        {
            var mapped = new List<IngredientAmount>();
            foreach (var ingredient in ingredients)
            {
                mapped.Add(new IngredientAmount
                {
                    IngredientIdId = ingredient.IngredientId,
                    Name = ingredient.Ingredient.Name,
                    Amount = ingredient.Amount1
                });
            }
            return mapped;
        }
    }
}