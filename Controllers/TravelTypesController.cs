﻿using System;
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
    public class TravelTypesController : ControllerBase
    {
        private readonly TravelContext _context;

        public TravelTypesController(TravelContext context)
        {
            _context = context;
        }

        // GET: api/TravelTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TravelType>>> GetTravelTypeList()
        {
            return await _context.TravelTypeList.ToListAsync();
        }

        // GET: api/TravelTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TravelType>> GetTravelType(int id)
        {
            var travelType = await _context.TravelTypeList.FindAsync(id);

            if (travelType == null)
            {
                return NotFound();
            }

            return travelType;
        }
    }
}
