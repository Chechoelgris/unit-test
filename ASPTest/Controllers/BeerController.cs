using ASPTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPTest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly IBeerService _beerService;

        public BeerController(IBeerService service)
        {
            _beerService = service;
        }
        [HttpGet]
        public IActionResult Get() => Ok(_beerService.Get());

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            var beer = _beerService.Get(id);
            if (beer == null)
            {
                return NotFound();
            }
            return Ok(beer);
        }



    }
}
