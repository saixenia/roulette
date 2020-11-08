using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace roulette.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        // GET: api/<RouletteController>
        [HttpGet]
        public int Get()
        {
            //create roulette
            //return rouletteId;
            return 1;
        }

        // GET api/<RouletteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RouletteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<RouletteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RouletteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
