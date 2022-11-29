﻿using CA.Recipe.Application.Exceptions;
using CA.Recipe.Application.Interfaces;
using CA.Recipe.Application.Services.Port;

namespace CA.Recipe.Testing.User.Mock
{
    public class UserGatewayMock : IUserGateway
    {
        public UserResponseDB InsertUser(UserRequest request)
        {
            if (request.email.Equals("noe_used@gmail.com"))
                throw new EmailInUseException();
            return new UserResponseDB
            {
                id = 1,
                username = request.username
            };
        }

        public void LoginUser()
        {
            throw new System.NotImplementedException();
        }
    }
}
