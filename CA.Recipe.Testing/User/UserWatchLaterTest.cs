using CA.Recipe.Application.Exceptions;
using CA.Recipe.Application.Services;
using CA.Recipe.Testing.User.Mock;
using CA.Recipe.Testing.WatchLater.Mock;
using NUnit.Framework;

namespace CA.Recipe.Testing.User
{
    public class UserWatchLaterTest
    {
        private UserService _useCase;
        [SetUp]
        public void Setup()
        {
            _useCase = new UserService(new UserGatewayMock(), new WatchLaterMock());
        }

        [TestCase(1,1)]
        public void AddWatchLater_Test(int userId, int recipeId)
        {
            _useCase.AddWatchLater(userId, recipeId);
        }

        [TestCase(0, 0)]
        [TestCase(-1, 1)]
        [TestCase(1, -1)]
        public void AddWatchLaterInvalidInt_Test(int userId, int recipeId)
        {
            Assert.Throws<InvalidRequestException>(() => _useCase.AddWatchLater(userId, recipeId));
        }

        [TestCase(1, 26)]
        public void AddWatchLaterAlreadyAdded_Test(int userId, int recipeId)
        {
            Assert.Throws<AlreadyAddedException>(() => _useCase.AddWatchLater(userId, recipeId));
        }
    }
}
