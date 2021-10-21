using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gttgBackend.Models.Interfaces.SQL
{
    public class SQLTripDataRepository : ITripDataRepository
    {

        private readonly AppDBContext context;

        public SQLTripDataRepository(AppDBContext context)
        {
            this.context = context;
        }
        public async Task<ActionResult<TripData>> AddTrip(TripData trip)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<TripData>> GetTripById(int id)
        {
            return await context.TripList.FindAsync(id);
        }

        public async Task<ActionResult<IEnumerable<TripData>>> GetTrips()
        {
            return await context.TripList.ToListAsync();
        }

        public async Task<ActionResult<TripData>> RemoveTrip(int id)
        {
            throw new NotImplementedException();
        }
    }
}
