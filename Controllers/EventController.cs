using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gttgBackend.Models;
using gttgBackend.Models.Interfaces;
using System.Threading.Tasks;

namespace gttgBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventDataRepository _context;

        public EventController(IEventDataRepository context)
        {
            _context = context;
        }

        // GET: api/Event
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventData>>> GetEventList()
        {
            return await _context.GetAllEvents();
        }

        // GET: api/Event/5
        [HttpGet("{planetID}")]
        public ActionResult<IEnumerable<EventData>> GetEventData(int planetID)
        {
            List<EventData> returnList = new();


            IEnumerable<EventData> eventList = _context.GetAllEvents().Result.Value;
            foreach (EventData planetEvent in eventList)
            {
                if (planetEvent.EventDataID == planetID)
                {
                    returnList.Add(planetEvent);
                }
            }

            return returnList;
        }
    }
}
