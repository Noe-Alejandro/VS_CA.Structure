//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CA.Recipe.FrameworksDrivers.Data.Recipe
{
    using System;
    using System.Collections.Generic;
    
    public partial class Amount
    {
        public int AmountId { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public int Amount1 { get; set; }
    
        public virtual Ingredient Ingredient { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}