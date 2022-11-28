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
        public List<StepRequest> Steps { get; set; }
        /*
        Nombre = "Prueba 1",
        Id = 1,
        Descripcion = "Rico platillo 1",
        Ingredientes = new List<Ingredientes> { new Ingredientes { Ingrediente = "1" }, new Ingredientes { Ingrediente = "2" } },
        Porciones = 4,
        Image = "https://www.annarecetasfaciles.com/files/arepas-colombianas-815x458.jpg",
        Pasos = new List<Pasos> { new Pasos { Paso = "Vivir" }, new Pasos { Paso = "Morir" } },
        Calificacion = 4.5*/
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

    public class StepRequest
    {
        public string Step { get; set; }
    }
}
