﻿using System;
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
            var result = await _context.TripList
                .Include(e => e.StartingPlanet)
                .Include(e => e.DestinationPlanet)
                .Include(e => e.CurrentlySelectedLodging)
                .Include(e => e.TravelType)
                .ToListAsync();
            return result;
        }

        // POST: api/Trip
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TripData>> PostTripData(TripData tripData)
        {
            System.Diagnostics.Debug.WriteLine("Getting post: " + tripData);
            List<TripData> dataInList = _context.TripList.ToList();

            if (dataInList.Count == 0) { 
            await _context.TripList.AddAsync(tripData);
                _context.Entry(tripData).State = EntityState.Added;
            } else {
                _context.TripList.Update(tripData);
                _context.Entry(tripData).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTripData", new { id = tripData.TripDataID }, tripData);
        }
    }
}