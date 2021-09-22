using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gttgBackend.Models;

namespace gttgBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LodgingController : ControllerBase
    {
        private readonly LodgingContext _context;

        public LodgingController(LodgingContext context)
        {
            _context = context;
        }

        // GET: api/Lodging
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LodgingData>>> GetLodgingList()
        {
            return await _context.LodgingList.ToListAsync();
        }

        // GET: api/Lodging/5
        [HttpGet("{planetID}")]
        public async Task<ActionResult<IEnumerable<LodgingData>>> GetLodgingData(int planetID)
        {
            List<LodgingData> returnList = new List<LodgingData>();


            List<LodgingData> lodgingList = await _context.LodgingList.ToListAsync();

            foreach (LodgingData lodging in lodgingList)
            {
                if (lodging.PlanetID == planetID)
                {
                    returnList.Add(lodging);
                }
            }

            return returnList;
        }
        private bool LodgingDataExists(int id)
        {
            return _context.LodgingList.Any(e => e.LodgingDataID == id);
        }
    }
}
