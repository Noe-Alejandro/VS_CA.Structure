﻿using System;
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
        public string Name { get; set; }
    }

    public class RecipeResponseDB
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class IngredientRequest
    {
        public int IngredientId { get; set; }
    }
}
