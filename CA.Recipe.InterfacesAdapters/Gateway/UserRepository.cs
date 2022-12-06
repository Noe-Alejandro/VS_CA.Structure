using CA.Recipe.Application.Exceptions;
using CA.Recipe.Application.Interfaces;
using CA.Recipe.Application.Services.Port;
using CA.Recipe.InterfacesAdapters.Data.Recipe;
using CA.Recipe.InterfacesAdapters.Helper;
using System.Linq;

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
            var user = _uowRecipe.UserRepository.Get(x => x.UserId.Equals(userId)).FirstOrDefault();
            if (user == null)
                throw new EntityNotFoundException("No se encontró el usuario con el id proporcionado");
            return MapperHelperInfra.Map<UserResponseDB>(user);
        }

        public UserResponseDB InsertUser(UserRequest request)
        {
            var userDB = _uowRecipe.UserRepository.Get(x => x.Email.Equals(request.email)).FirstOrDefault();
            if (userDB != null)
                throw new AlreadyAddedException("Ya se encuentra en uso el correo proporcionado");
            var user = MapperHelperInfra.Map<User>(request);
            _uowRecipe.UserRepository.Insert(user);
            _uowRecipe.Save();
            return MapperHelperInfra.Map<UserResponseDB>(user);
        }

        public UserResponseDB LoginUser(UserRequest request)
        {
            var user = _uowRecipe.UserRepository.Get(x => x.Email.Equals(request.email)).FirstOrDefault();
            if (user == null)
                throw new EntityNotFoundException("Correo o contraseña inválida");
            if (!user.Password.Equals(request.password))
                throw new EntityNotFoundException("Correo o contraseña inválida");
            return MapperHelperInfra.Map<UserResponseDB>(user);
        }

        public void UpdateUser(int userId, UserEditRequest request)
        {
            var user = _uowRecipe.UserRepository.Get(x => x.UserId.Equals(userId)).FirstOrDefault();
            if (user == null)
                throw new EntityNotFoundException("No se encontró el usuario con el id proporcionado");
            var emailInUse = _uowRecipe.UserRepository.Get(x => x.Email.Equals(request.NewEmail) && !x.UserId.Equals(userId)).FirstOrDefault();
            if (emailInUse != null)
                throw new EmailInUseException("El nuevo correo ya se encuentra en uso por otro usuario");
            user.Email = request.NewEmail;
            user.Password = request.NewPassword;
            _uowRecipe.Save();
        }
    }
}