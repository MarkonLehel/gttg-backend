using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using gttgBackend.Models;
using gttgBackend.Models.Interfaces;

namespace gttgBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LodgingController : ControllerBase
    {
        private readonly ILodgingDataRepository _context;

        public LodgingController(ILodgingDataRepository context)
        {
            _context = context;
        }

        // GET: api/Lodging
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LodgingData>>> GetLodgingList()
        {
            return await _context.GetAllLodgings();
        }

        // GET: api/Lodging/5
        [HttpGet("{planetID}")]
        public async Task<ActionResult<IEnumerable<LodgingData>>> GetLodgingDataForPlanet(int planetID)
        {
            List<LodgingData> returnList = new();

            ActionResult<IEnumerable<LodgingData>> actionResult = await _context.GetAllLodgings();
            IEnumerable<LodgingData> lodgingList = actionResult.Value;

            foreach (LodgingData lodging in lodgingList)
            {
                if (lodging.PlanetID == planetID)
                {
                    returnList.Add(lodging);
                }
            }
            return returnList;
        }
    }
}
