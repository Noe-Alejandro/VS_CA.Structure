using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Recipe.Application.Exceptions
{
    public class AlreadyAddedException : Exception
    {
        public AlreadyAddedException(string message) : base(message)
        {
        }
    }
}
