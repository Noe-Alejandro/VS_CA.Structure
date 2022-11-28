using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Recipe.Application.Exceptions
{
    public class InvalidRequestException : Exception
    {
        public InvalidRequestException(string message="Solicitud inválida") : base(message)
        {
        }
    }
}
