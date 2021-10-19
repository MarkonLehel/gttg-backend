using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace gttgBackend.Models.Interfaces
{
    interface ITripDataRepository
    {
        Task<ActionResult<TripData>> GetTripById(int id);
        Task<ActionResult<EventData>> GetTrips(int id);
    }
}
