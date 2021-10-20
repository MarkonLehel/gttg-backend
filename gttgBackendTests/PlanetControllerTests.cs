
using gttgBackend.Controllers;
using gttgBackend.Models.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace gttgBackendTests
{
    public class PlanetControllerTests
    {
        IPlanetDataRepository planetContext;

        [SetUp]
        public void Setup()
        {
            planetContext = Substitute.For<IPlanetDataRepository>();
        }

        [Test]
        public void TestPlanetControllerConstructorShouldReturnNotNull()
        {
            PlanetController planetController = new PlanetController(planetContext);
            Assert.IsNotNull(planetController);
        }

        [Test]
        public void TestGetPlanetListShouldReturnNotNull()
        {
            PlanetController planetController = new PlanetController(planetContext);
            var planets = planetController.GetPLanetList();
            Assert.IsNotNull(planets);
        }

        [Test]
        public void TestGetPlanetDataShouldReturnNotNull()
        {
            PlanetController planetController = new PlanetController(planetContext);
            var planet = planetController.GetPLanetList();
            Assert.IsNotNull(planet);
        }
    }
}