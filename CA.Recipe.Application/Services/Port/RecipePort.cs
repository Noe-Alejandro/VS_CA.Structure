using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Recipe.Application.Services.Port
{
    public class RecipeRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<IngredientRequest> Ingredients { get; set; }
        public int Portions { get; set; }
        public string Image { get; set; }
        public string Steps { get; set; }
    }

    public class RecipeResponse
    {
        public int Id { get; set; }
    }

    public class RecipeCoverResponse
    {
        public int RecipeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public float Score { get; set; }
    }

    public class RecipeDetailResponse
    {
        public int RecipeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<IngredientAmount> Ingredients { get; set; }
        public int Portions { get; set; }
        public string Steps { get; set; }

        public float Score { get; set; }
        public string Author { get; set; }
    }

    public class IngredientAmount
    {
        public int IngredientIdId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
    }

    public class RecipeResponseDB
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<IngredientAmount> Ingredients { get; set; }

        public float Score { get; set; }
    }

    public class IngredientRequest
    {
        public int IngredientId { get; set; }
        public int Amount { get; set; }
    }
}
