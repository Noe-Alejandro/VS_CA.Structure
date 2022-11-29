using CA.Recipe.Application.Services.Port;

namespace CA.Recipe.Application.Interfaces
{
    public interface IUserGateway
    {
        UserResponseDB InsertUser(UserRequest request);
        void LoginUser();
    }
}
