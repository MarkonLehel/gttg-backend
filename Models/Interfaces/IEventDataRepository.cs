using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gttgBackend.Models.Interfaces.SQL
{
    interface IEventDataRepository
    {
        Task<ActionResult<EventData>> GetLodgingById(int id);
        Task<ActionResult<IEnumerable<EventData>>> GetAllLodgings();
    }
}
