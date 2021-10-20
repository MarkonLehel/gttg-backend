
using gttgBackend.Controllers;
using gttgBackend.Models.Interfaces;
using NSubstitute;
using NUnit.Framework;

using System.Linq;

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
            System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult<System.Collections.Generic.IEnumerable<gttgBackend.Models.PlanetData>>> planet = planetController.GetPLanetList();
            System.Console.WriteLine(planet);
            System.Console.WriteLine(planet.Status);
            System.Console.WriteLine(planet.IsCompleted);
            System.Console.WriteLine(planet.Result);
            if (planet.Result == null)
                System.Console.WriteLine("null");
            System.Console.WriteLine("what?");
            Assert.IsNotNull(planet);
        }
    }
}