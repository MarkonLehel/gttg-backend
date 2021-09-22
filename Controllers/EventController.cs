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
    public class EventController : ControllerBase
    {
        private readonly EventContext _context;

        public EventController(EventContext context)
        {
            _context = context;
        }

        // GET: api/Event
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventData>>> GetEventList()
        {
            return await _context.EventList.ToListAsync();
        }

        // GET: api/Event/5
        [HttpGet("{planetID}")]
        public async Task<ActionResult<IEnumerable<EventData>>> GetEventData(int planetID)
        {
            List<EventData> returnList = new List<EventData>();


            List<EventData> eventList = await _context.EventList.ToListAsync();

            foreach (EventData planetEvent in eventList)
            {
                if (planetEvent.EventDataID == planetID)
                {
                    returnList.Add(planetEvent);
                }
            }

            return returnList;
        }

        private bool EventDataExists(int id)
        {
            return _context.EventList.Any(e => e.EventDataID == id);
        }
    }
}
