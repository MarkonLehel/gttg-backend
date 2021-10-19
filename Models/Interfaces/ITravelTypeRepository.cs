using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gttgBackend.Models.Interfaces
{
    public interface ITravelTypeRepository
    {
        Task<ActionResult<TravelType>> GetTravelTypeById(int id);
        Task<ActionResult<IEnumerable<TravelType>>> GetAllTravelTypes();
    }
}
