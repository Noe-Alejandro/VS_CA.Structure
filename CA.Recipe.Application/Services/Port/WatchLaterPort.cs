using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Recipe.Application.Services.Port
{
    public class WatchLaterRequest
    {
        public int userId { get; set; }
        public int recipeId { get; set; }
    }
}
