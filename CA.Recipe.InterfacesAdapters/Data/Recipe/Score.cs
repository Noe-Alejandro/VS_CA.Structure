//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CA.Recipe.InterfacesAdapters.Data.Recipe
{
    using System;
    using System.Collections.Generic;
    
    public partial class Score
    {
        public int ScoreId { get; set; }
        public int RecipeId { get; set; }
        public int UserId { get; set; }
        public int Score1 { get; set; }
    
        public virtual Recipe Recipe { get; set; }
        public virtual User User { get; set; }
    }
}