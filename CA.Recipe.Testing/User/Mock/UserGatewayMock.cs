using CA.Recipe.Application.Exceptions;
using CA.Recipe.Application.Interfaces;
using CA.Recipe.Application.Services.Port;
using System.Collections.Generic;

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

        public UserResponseDB LoginUser(UserRequest request)
        {
            var user = users.Find(x => x.email.Equals(request.email));
            if (user == null)
                throw new EntityNotFoundException("Correo o contraseña inválida");
            if (!user.password.Equals(request.password))
                throw new EntityNotFoundException("Correo o contraseña inválida");
            return user;
        }

        public UserResponseDB GetUser(int userId)
        {
            UserResponseDB user = users.Find(x => x.id.Equals(userId));
            return user;
        }

        public void UpdateUser(int userId, UserEditRequest request)
        {
            UserResponseDB user = users.Find(x => x.id.Equals(userId));
            if(!user.password.Equals(request.Password))
                throw new IncorrectPasswordException("Contraseña incorrecta");
            if (users.Find(x => x.email.Equals(request.NewEmail)) != null)
                throw new EmailInUseException("El correo se encuentra en uso por otra cuenta");
            user.email = request.NewEmail;
            user.password = request.NewPassword;
        }

        private List<UserResponseDB> users = new List<UserResponseDB>()
        {
            new UserResponseDB(){ id = 1, username = "noeshi", email = "noe@gmail.com", usertype = 2, password="gato1"},
            new UserResponseDB(){ id = 2, username = "noeshi2", email = "noe2@gmail.com", usertype = 2, password="gato2"},
            new UserResponseDB(){ id = 3, username = "noeshi3", email = "noe3@gmail.com", usertype = 2, password = "gato3"}
        };
    }
}
