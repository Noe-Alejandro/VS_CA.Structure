using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Recipe.Application.Exceptions
{
    public class EmailInUseException : Exception
    {
        public EmailInUseException(string message="El email ingresado ya se encuentra en uso") : base(message)
        {
        }
    }
}
