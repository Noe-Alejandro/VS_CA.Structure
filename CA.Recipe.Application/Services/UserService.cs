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
            var responseDB = _iUserGateway.InsertUser(request);
            return new UserResponse { id = responseDB.id, username = responseDB.username };
        }

        public void WatchLater()
        {
            _iWatchLaterGateway.AddWatchLater();
            return;
        }
    }
}