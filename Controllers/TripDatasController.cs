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
    public class TripDatasController : ControllerBase
    {
        private readonly TripContext _context;

        public TripDatasController(TripContext context)
        {
            _context = context;
        }

        // GET: api/TripDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TripData>>> GetTripItems()
        {
            return await _context.TripItems.ToListAsync();
        }

        // GET: api/TripDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TripData>> GetTripData(int id)
        {
            var tripData = await _context.TripItems.FindAsync(id);

            if (tripData == null)
            {
                return NotFound();
            }

            return tripData;
        }

        // PUT: api/TripDatas/5
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

        // POST: api/TripDatas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TripData>> PostTripData(TripData tripData)
        {
            _context.TripItems.Add(tripData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTripData", new { id = tripData.TripDataID }, tripData);
        }

        // DELETE: api/TripDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTripData(int id)
        {
            var tripData = await _context.TripItems.FindAsync(id);
            if (tripData == null)
            {
                return NotFound();
            }

            _context.TripItems.Remove(tripData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TripDataExists(int id)
        {
            return _context.TripItems.Any(e => e.TripDataID == id);
        }
    }
}
