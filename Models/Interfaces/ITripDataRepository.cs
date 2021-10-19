using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gttgBackend.Models.Interfaces
{
    interface ITripDataRepository
    {
        Task<ActionResult<TripData>> GetTripById(int id);
        Task<ActionResult<IEnumerable<TripData>>> GetTrips();

        Task<ActionResult<TripData>> AddTrip(TripData trip);

        Task<ActionResult<TripData>> RemoveTrip(int id);

    }
}
