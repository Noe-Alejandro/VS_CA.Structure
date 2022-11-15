using CA.Recipe.Application.Interfaces;
using CA.Recipe.Application.Services.PortResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Recipe.Testing.Disc.Mock
{
    public class DiscGatewayMock : IDiscGateway
    {
        public DiscDTO CreateDisc()
        {
            return new DiscDTO { ID = 1, Name = "Prueba" };
        }
    }
}
