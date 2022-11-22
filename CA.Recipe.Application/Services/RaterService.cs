using CA.Recipe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Recipe.Application.Services
{
    public class RaterService
    {
        private IScoreGateway _iScoreGateway;
        public RaterService(IScoreGateway iScoreGateway)
        {
            _iScoreGateway = iScoreGateway;
        }

        public void GiveAScore()
        {
            _iScoreGateway.SetScore();
            return;
        }
    }
}
