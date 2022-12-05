using CA.Recipe.Application.Exceptions;
using CA.Recipe.Application.Interfaces;
using CA.Recipe.Application.Services.Port;
using CA.Recipe.InterfacesAdapters.Data.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CA.Recipe.InterfacesAdapters.Gateway
{
    public class UserRepository : IUserGateway
    {
        private readonly UoWRecipe _uowRecipe;
        public UserRepository(UoWRecipe uowRecipe)
        {
            _uowRecipe = uowRecipe;
        }

        public UserResponseDB GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        public UserResponseDB InsertUser(UserRequest request)
        {
            var user = new User
            {
                UserName = request.username,
                Email = request.email,
                UserType = 2,
                Password = request.password,
                Active = true
            };
            _uowRecipe.UserRepository.Insert(user);
            _uowRecipe.Save();
            return new UserResponseDB
            {
                id = user.UserId, email = user.Email, password = user.Password, username = user.UserName, usertype = user.UserType
            };
        }

        public UserResponseDB LoginUser(UserRequest request)
        {
            var user = _uowRecipe.UserRepository.Get(x => x.Email.Equals(request.email)).FirstOrDefault();
            if (user == null)
                throw new EntityNotFoundException("Correo o contraseña inválida");
            if (!user.Password.Equals(request.password))
                throw new EntityNotFoundException("Correo o contraseña inválida");
            return new UserResponseDB
            {
                id = user.UserId,
                username = user.UserName
            };
        }

        public void UpdateUser(int userId, UserEditRequest request)
        {
            throw new NotImplementedException();
        }
    }
}