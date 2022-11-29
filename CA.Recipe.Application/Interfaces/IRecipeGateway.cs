using CA.Recipe.Application.Services.Port;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Recipe.Application.Interfaces
{
    public interface IRecipeGateway
    {
        RecipeResponseDB InsertRecipe(RecipeRequest recipe);
        RecipeDetailResponse GetRecipe(int id);
        List<RecipeCoverResponse> GetAllRecipe();
        RecipeResponseDB UpdateRecipe(int recipeId, RecipeRequest request);
        List<RecipeCoverResponse> FindByTitle(string title);
        List<RecipeCoverResponse> FindByIngredients(List<int> ingredientIdLst);
        //Obtener receta de forma aleatoria
    }
}
