using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Recipe.Application.Services.Port
{
    public class ScoreRequest
    {
        public int recipeId { get; set; }
        public int userId { get; set; }
        public int score { get; set; }
    }
}
