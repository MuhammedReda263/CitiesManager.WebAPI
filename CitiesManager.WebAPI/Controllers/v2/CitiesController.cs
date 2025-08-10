using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CitiesManager.WebAPI.DatabaseContext;
using CitiesManager.WebAPI.Models;
using Asp.Versioning;

namespace CitiesManager.WebAPI.Controllers.v2
{

    [ApiVersion("2.0")]

    public class CitiesController : CustomControllerBase
    {
        private readonly ApllicationDbContext _context;

        public CitiesController(ApllicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Cities
        /// <summary>
        /// To get list of cities include cityName only from "cities" table
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        // [Produces("application/xml")] // custom the type content of response body 
        public async Task<ActionResult<IEnumerable<string>>> GetCities()
        {
            return await _context.Cities.Select(temp=>temp.Name).ToListAsync();
        }



    }
}

// Note 
// if you will return only object you can use ActionResylt <T> but if you will return diffrent results use IActionResult