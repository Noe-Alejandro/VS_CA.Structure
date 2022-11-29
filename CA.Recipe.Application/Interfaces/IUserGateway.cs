using CA.Recipe.Application.Services.Port;

namespace CA.Recipe.Application.Interfaces
{
    public interface IUserGateway
    {
        UserResponseDB InsertUser(UserRequest request);
        UserResponseDB LoginUser(UserRequest request);
    }
}
