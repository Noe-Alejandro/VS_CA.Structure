using CA.Recipe.Application.DS;
using CA.Recipe.Application.Interfaces;
using CA.Recipe.Application.Services.PortResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Recipe.Application.Services
{
    public class DiscService
    {
        private IDiscGateway _iDiscGateway;
        public DiscService(IDiscGateway iDiscGateway)
        {
            _iDiscGateway = iDiscGateway;
        }

        public Disc Add()
        {
            //Some validations of Disc
            DiscDTO disc = _iDiscGateway.CreateDisc();
            return new Disc
            {
                ID = disc.ID,
                Name = disc.Name
            };
        }
    }
}
