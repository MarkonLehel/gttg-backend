using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gttgBackend.Models.Interfaces.SQL
{
    public class SQLPlanetDataRepository : IPlanetDataRepository
    {
        private readonly AppDBContext context;

        public SQLPlanetDataRepository(AppDBContext context)
        {
            this.context = context;
        }


        public async Task<ActionResult<IEnumerable<PlanetData>>> GetAllPlanets()
        {
            return await context.PLanetList.ToListAsync();
        }

        public async Task<ActionResult<PlanetData>> GetPlanetById(int id)
        {
            return await context.PLanetList.FindAsync(id);
        }
    }
}
