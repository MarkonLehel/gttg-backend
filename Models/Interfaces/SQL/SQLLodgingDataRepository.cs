using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gttgBackend.Models.Interfaces.SQL
{
    public class SQLLodgingDataRepository : ILodgingDataRepository
    {
        private readonly AppDBContext context;

        public SQLLodgingDataRepository(AppDBContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<IEnumerable<LodgingData>>> GetAllLodgings()
        {
            return await context.LodgingList.ToListAsync();
        }

        public async Task<ActionResult<LodgingData>> GetLodgingById(int id)
        {
            return await context.LodgingList.FindAsync(id);
        }
    }
}
