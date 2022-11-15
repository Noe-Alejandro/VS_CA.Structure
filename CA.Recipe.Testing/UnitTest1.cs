using CA.Recipe.Application.Services;
using CA.Recipe.Application.Services.PortResponses;
using CA.Recipe.Testing.Disc.Mock;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CA.Recipe.Testing
{
    public class Tests
    {
        private DiscService _useCase;

        [SetUp]
        public void Setup()
        {
            _useCase = new DiscService(new DiscGatewayMock());
        }

        [Test]
        public void Test1()
        {
            var expectedObject = new DiscDTO { ID = 1, Name = "Prueba"};
            var expectedValue = JsonConvert.SerializeObject(expectedObject);
            Assert.AreEqual(expectedValue, JsonConvert.SerializeObject(_useCase.Add()));
        }
    }
}