using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gttgBackend.Models.Interfaces
{
    public interface IPlanetDataRepository
    {
        Task<ActionResult<PlanetData>> GetPlanetById(int id);
        Task<ActionResult<IEnumerable<PlanetData>>> GetAllPlanets();

    }
}
