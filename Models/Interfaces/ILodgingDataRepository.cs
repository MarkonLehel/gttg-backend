using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gttgBackend.Models.Interfaces
{
    public interface ILodgingDataRepository
    {
        Task<ActionResult<LodgingData>> GetLodgingById(int id);
        Task<ActionResult<IEnumerable<LodgingData>>> GetAllLodgings();
    }
}
