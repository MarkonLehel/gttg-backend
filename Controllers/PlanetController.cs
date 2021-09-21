using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gttgBackend.Models;

namespace gttgBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetController : ControllerBase
    {
        private readonly PlanetContext _context;

        public PlanetController(PlanetContext context)
        {
            _context = context;
        }

        // GET: api/Planet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlanetData>>> GetPLanetList()
        {
            return await _context.PLanetList.ToListAsync();
        }

        // GET: api/Planet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlanetData>> GetPlanetData(int id)
        {
            var planetData = await _context.PLanetList.FindAsync(id);

            if (planetData == null)
            {
                return NotFound();
            }

            return planetData;
        }

        // PUT: api/Planet/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlanetData(int id, PlanetData planetData)
        {
            if (id != planetData.PlanetDataID)
            {
                return BadRequest();
            }

            _context.Entry(planetData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanetDataExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Planet
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlanetData>> PostPlanetData(PlanetData planetData)
        {
            _context.PLanetList.Add(planetData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlanetData", new { id = planetData.PlanetDataID }, planetData);
        }

        // DELETE: api/Planet/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanetData(int id)
        {
            var planetData = await _context.PLanetList.FindAsync(id);
            if (planetData == null)
            {
                return NotFound();
            }

            _context.PLanetList.Remove(planetData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlanetDataExists(int id)
        {
            return _context.PLanetList.Any(e => e.PlanetDataID == id);
        }
    }
}
