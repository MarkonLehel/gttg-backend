using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gttgBackend.Models;
using Microsoft.AspNetCore.Cors;
using gttgBackend.Models.Interfaces;

namespace gttgBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetController : ControllerBase
    {
        private readonly IPlanetDataRepository _context;

        public PlanetController(IPlanetDataRepository context)
        {
            _context = context;
        }

        // GET: api/Planet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlanetData>>> GetPLanetList()
        {
            return await _context.GetAllPlanets();
        }

        // GET: api/Planet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlanetData>> GetPlanetData(int id)
        {
            var planetData = await _context.GetPlanetById(id);

            if (planetData == null)
            {
                return NotFound();
            }

            return planetData;
        }
    }
}
