﻿using CA.Recipe.Application.Exceptions;
using CA.Recipe.Application.Interfaces;
using CA.Recipe.Application.Services.Port;
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

        public UserResponse LoginUser(UserRequest request)
        {
            if (request.email == null || request.email.Trim().Equals(""))
                throw new InvalidRequestException("Debe ingresar un email");
            if (request.password == null || request.password.Trim().Equals(""))
                throw new InvalidRequestException("Debe ingresar la contraseña");
            UserResponseDB response = _iUserGateway.LoginUser(request);
            return new UserResponse
            {
                id = response.id,
                username = response.username
            };
        }
    }
}
