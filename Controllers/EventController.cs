using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<IEnumerable<EventData>>> GetEventDataForPlanet(int planetID)
        {
            List<EventData> returnList = new();

            ActionResult<IEnumerable<EventData>> actionResult = await _context.GetAllEvents();
            IEnumerable<EventData> eventList = actionResult.Value;
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
