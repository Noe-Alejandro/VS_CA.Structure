using CA.Recipe.Application.Exceptions;
using CA.Recipe.Application.Services;
using CA.Recipe.Application.Services.Port;
using CA.Recipe.Testing.User.Mock;
using CA.Recipe.Testing.WatchLater.Mock;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Recipe.Testing.User
{
    public class UserUpdateTest
    {
        private UserService _useCase;
        [SetUp]
        public void Setup()
        {
            _useCase = new UserService(new UserGatewayMock(), new WatchLaterMock());
        }

        [TestCase(1)]
        public void UpdateUser_Test(int userId)
        {
            _useCase.EditUser(userId, new UserEditRequest
            {
                NewEmail = "noe4@gmail.com",
                NewPassword = "gato4",
                Password = "gato1"
            });
        }

        [TestCase(1)]
        public void UpdateUserEmailInUse_Test(int userId)
        {
            Assert.Throws<EmailInUseException>(() => _useCase.EditUser(userId, new UserEditRequest
            {
                NewEmail = "noe3@gmail.com",
                NewPassword = "gato4",
                Password = "gato1"
            }));
        }

        [TestCase(1)]
        public void UpdateUserIncorrectPassword_Test(int userId)
        {
            Assert.Throws<IncorrectPasswordException>(() => _useCase.EditUser(userId, new UserEditRequest
            {
                NewEmail = "noe4@gmail.com",
                NewPassword = "gato4",
                Password = "gato2"
            }));
        }
    }
}
