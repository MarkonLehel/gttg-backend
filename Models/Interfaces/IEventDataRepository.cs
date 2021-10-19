using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gttgBackend.Models.Interfaces
{
    public interface IEventDataRepository
    {
        Task<ActionResult<EventData>> GetEventById(int id);
        Task<ActionResult<IEnumerable<EventData>>> GetAllEvents();
    }
}
