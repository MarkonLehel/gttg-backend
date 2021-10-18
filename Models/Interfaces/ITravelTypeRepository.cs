using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gttgBackend.Models.Interfaces
{
    public interface ITravelTypeRepository
    {
        Task<ActionResult<TravelType>> GetLodgingById(int id);
        Task<ActionResult<IEnumerable<TravelType>>> GetAllLodgings();
    }
}
