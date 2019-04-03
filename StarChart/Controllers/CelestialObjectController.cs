using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarChart.Data;

namespace StarChart.Controllers
{
    [Route("")]
    [ApiController]
    public class CelestialObjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CelestialObjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet ("{id:int}", Name = "GetById")]
        public IActionResult GetById(int id)
        {
            if(_context.CelestialObjects.Count(r => r.Id == id)==0)
            {
                return NotFound();
            }

            var celestialObject = _context.CelestialObjects.FirstOrDefault(r => r.Id == id);
            return Ok(celestialObject);
        }
    }
}
