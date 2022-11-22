using CA.Recipe.Application.Interfaces;
using CA.Recipe.Application.Services.Port;

namespace CA.Recipe.Testing.User.Mock
{
    public class UserGatewayMock : IUserGateway
    {
        public UserResponseDB InsertUser(UserRequest request)
        {
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
