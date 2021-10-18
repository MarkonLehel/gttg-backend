using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gttgBackend.Models.Interfaces.SQL
{
    public class SQLTravelTypeRepository : ITravelTypeRepository
    {
        private readonly AppDBContext context;

        public SQLTravelTypeRepository(AppDBContext context)
        {
            this.context = context;
        }
        public async Task<ActionResult<IEnumerable<TravelType>>> GetAllLodgings()
        {
            return await context.TravelTypeList.ToListAsync();
        }

        public async Task<ActionResult<TravelType>> GetLodgingById(int id)
        {
            return await context.TravelTypeList.FindAsync(id);
        }
    }
}
