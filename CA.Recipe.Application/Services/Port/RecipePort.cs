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
        public string Author { get; set; }
    }

    public class RecipeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
    }

    public class RecipeResponseDB
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
    }
}
