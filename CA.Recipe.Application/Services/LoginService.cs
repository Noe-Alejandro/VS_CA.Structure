using CA.Recipe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Recipe.Application.Services
{
    public class LoginService
    {
        private IUserGateway _iUserGateway;
        public LoginService(IUserGateway iUserGateway)
        {
            _iUserGateway = iUserGateway;
        }

        public void LoginUser()
        {
            _iUserGateway.LoginUser();
            return;
        }
    }
}
