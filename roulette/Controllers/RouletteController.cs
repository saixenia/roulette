using Microsoft.AspNetCore.Mvc;
using Roulette.Interfaces;
using Roulette.Models;
using System.Collections.Generic;

namespace roulette.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private readonly IRouletteService _rouletteService;

        public RouletteController(IRouletteService rouletteService)
        {
            _rouletteService = rouletteService;
        }

        [HttpGet]
        public List<Roulettes> GetRoulettesCreated()
        {

            return _rouletteService.GetRoulettesCreated();
        }

        [HttpPost]
        public ActionResult<Roulettes> CreateRoulette()
        {

            return CreatedAtAction(nameof(CreateRoulette), _rouletteService.CreateRoulette());
        }

        [HttpPost]
        [Route("OpenRoulette")]
        public ActionResult OpenRoulette(Roulettes roulette)
        {

            if (!_rouletteService.OpenRoulette(roulette))
            {

                return NotFound();
            }

            return Ok();
        }
    }
}