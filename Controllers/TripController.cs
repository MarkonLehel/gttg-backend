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

        // POST: api/Trip
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TripData>> PostTripData(TripData tripData)
        {
            System.Diagnostics.Debug.WriteLine("Getting post: " + tripData);
            List<TripData> dataInList = _context.TripList.ToList();

            if (dataInList.Count == 0) { 
            _context.TripList.Add(tripData);
            } else {
                _context.TripList.Update(tripData);
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTripData", new { id = tripData.TripDataID }, tripData);
        }
    }
}
