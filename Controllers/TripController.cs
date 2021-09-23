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
    public class TripController : ControllerBase
    {
        private readonly TripContext _context;

        public TripController(TripContext context)
        {
            _context = context;
        }

        // GET: api/Trip
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TripData>>> GetTripList()
        {
            return await _context.TripList.ToListAsync();
        }

        // GET: api/Trip/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TripData>> GetTripData(int id)
        {
            var tripData = await _context.TripList.FindAsync(id);

            if (tripData == null)
            {
                return NotFound();
            }

            return tripData;
        }

        // PUT: api/Trip/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTripData(int id, TripData tripData)
        {
            if (id != tripData.TripDataID)
            {
                return BadRequest();
            }

            _context.Entry(tripData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TripDataExists(id))
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

        // POST: api/Trip
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TripData>> PostTripData(TripData tripData)
        {
            _context.TripList.Add(tripData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTripData", new { id = tripData.TripDataID }, tripData);
        }

        // DELETE: api/Trip/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTripData(int id)
        {
            var tripData = await _context.TripList.FindAsync(id);
            if (tripData == null)
            {
                return NotFound();
            }

            _context.TripList.Remove(tripData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TripDataExists(int id)
        {
            return _context.TripList.Any(e => e.TripDataID == id);
        }
    }
}
