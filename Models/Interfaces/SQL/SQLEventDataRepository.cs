using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gttgBackend.Models.Interfaces.SQL
{
    public class SQLEventDataRepository : IEventDataRepository
    {
        private readonly AppDBContext context;

        public SQLEventDataRepository(AppDBContext context)
        {
            this.context = context;
        }
        public async Task<ActionResult<IEnumerable<EventData>>> GetAllEvents()
        {
            return await context.EventList.ToListAsync();
        }

        public async Task<ActionResult<EventData>> GetEventById(int id)
        {
            return await context.EventList.FindAsync(id);
        }
    }
}
