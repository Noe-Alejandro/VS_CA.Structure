using CA.Recipe.Application.Exceptions;
using CA.Recipe.Application.Interfaces;
using CA.Recipe.Application.Services.Port;

namespace CA.Recipe.Application.Services
{
    public class UserService
    {
        private IUserGateway _iUserGateway;
        private IWatchLaterGateway _iWatchLaterGateway;
        public UserService(IUserGateway iUserGateway, IWatchLaterGateway iWatchLaterGateway)
        {
            _iUserGateway = iUserGateway;
            _iWatchLaterGateway = iWatchLaterGateway;
        }

        public UserResponse RegisterUser(UserRequest request)
        {
            if (request.email == null || request.email.Trim().Equals(""))
                throw new InvalidRequestException("Debe ingresarse un email");
            if (request.password == null || request.password.Trim().Equals(""))
                throw new InvalidRequestException("Debe ingresarse una contraseña");
            if (request.username == null || request.username.Trim().Equals(""))
                throw new InvalidRequestException("Debe ingresarse un username");
            UserResponseDB responseDB = _iUserGateway.InsertUser(request);
            return new UserResponse { id = responseDB.id, username = responseDB.username };
        }

        public void AddWatchLater(int userId, int recipeId)
        {
            if (userId <= 0)
                throw new InvalidRequestException("Ingrese un id de usuario válido");
            if (recipeId <= 0)
                throw new InvalidRequestException("Ingrese un id de receta válido");
            _iWatchLaterGateway.AddWatchLater(userId, recipeId);
            return;
        }
    }
}