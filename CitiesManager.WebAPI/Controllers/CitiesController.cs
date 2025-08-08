using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CitiesManager.WebAPI.DatabaseContext;
using CitiesManager.WebAPI.Models;

namespace CitiesManager.WebAPI.Controllers
{
   
    public class CitiesController : CustomControllerBase
    {
        private readonly ApllicationDbContext _context;

        public CitiesController(ApllicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCities()
        {
            return await _context.Cities.ToListAsync();
        }

        // GET: api/Cities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCity(Guid id)
        {
            var city = await _context.Cities.FirstOrDefaultAsync(x=>x.Id==id);

            if (city == null)
            {
                return Problem(detail: "Invalid CityId", statusCode: 400, title: "City Search");
                 //return NotFound();
            }

            return city;
        }

        // PUT: api/Cities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(Guid id,[Bind(nameof(City.Id),(nameof(City.Name)))] City city)
        {
            if (id != city.Id)
            {
                return BadRequest(); // HTTP 400
            }

            var exsistingCity = await _context.Cities.FindAsync(id);
            if (exsistingCity == null) { return NotFound(); } // HTTP 404
            exsistingCity.Name = city.Name;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent(); //HTTP 200
        }

        // POST: api/Cities
        [HttpPost]
        public async Task<ActionResult<City>> PostCity([Bind(nameof(City.Id),nameof(City.Name))]City city)
        {
            if (_context.Cities.Any(c => c.Id == city.Id))
            {
                return Conflict("City with this Id already exists.");
            }

            _context.Cities.Add(city);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCity", new { id = city.Id }, city); // api/Cities/{Id}  //HTTP 201
        }

        // DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(Guid id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound(); // HTTP 404
            }

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();

            return NoContent(); // HTTP 200
        }

        private bool CityExists(Guid id)
        {
            return _context.Cities.Any(e => e.Id == id);
        }
    }
}

// Note 
// if you will return only object you can use ActionResylt <T> but if you will return diffrent results use IActionResult