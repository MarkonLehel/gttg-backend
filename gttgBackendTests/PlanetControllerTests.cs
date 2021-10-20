
using gttgBackend.Controllers;
using gttgBackend.Models.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace gttgBackendTests
{
    public class PlanetControllerTests
    {
        IPlanetDataRepository planetContext;
        PlanetController planetController;

        [SetUp]
        public void Setup()
        {
            planetContext = Substitute.For<IPlanetDataRepository>();
            planetController = new PlanetController(planetContext);
        }

        [Test]
        public void TestPlanetControllerConstructorShouldReturnNotNull()
        {
            Assert.IsNotNull(planetController);
        }

        [Test]
        public void TestGetPlanetListShouldReturnNotNull()
        {
            var planets = planetController.GetPLanetList();
            Assert.IsNotNull(planets);
        }

        [Test]
        public void TestGetPlanetDataShouldReturnNotNull()
        {
            var planet = planetController.GetPLanetList();
            Assert.IsNotNull(planet);
        }
    }
}