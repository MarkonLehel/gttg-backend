
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
        public void TestPlanetControllerConstructor()
        {
            PlanetController planetController = new PlanetController(planetContext);
            Assert.IsNotNull(planetController);
        }
    }
}