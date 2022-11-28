using CA.Recipe.Application.Exceptions;
using CA.Recipe.Application.Services;
using CA.Recipe.Application.Services.Port;
using CA.Recipe.Testing.Rater.Mock;
using CA.Recipe.Testing.Recipe.Mock;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;

namespace CA.Recipe.Testing.Rater
{
    public class RaterGiveAScoreTest
    {
        private RaterService _useCase;
        [SetUp]
        public void Setup()
        {
            _useCase = new RaterService(new RaterGatewayMock());
        }

        [TestCase(ExpectedResult = true)]
        public bool GiveAScore_Test()
        {
            return _useCase.GiveAScore(1, 1, 1);
        }

        [TestCase(0,1,1)]
        [TestCase(1, 0, 1)]
        [TestCase(1, 1, -1)]
        [TestCase(1, 1, 6)]
        public void GiveAScoreInvalidId_Test(int recipeId, int userId, int score)
        {
            Assert.Throws<InvalidRequestException>(() => _useCase.GiveAScore(recipeId, userId, score));
        }
    }
}
