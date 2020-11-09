using Microsoft.AspNetCore.Mvc;
using Roulette.Interfaces;
using Roulette.Models;
using System.Collections.Generic;

namespace Roulette.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetController : ControllerBase
    {
        private readonly IBetService _betService;

        public BetController(IBetService betService)
        {
            _betService = betService;
        }

        [HttpPost]
        public ActionResult BetByUser(Bets bets)
        {
            if (!_betService.ValidateBet(bets))
            {
                return BadRequest("The bet fail");
            }

            return Ok("Bet add success");
        }

        [HttpPost]
        [Route("ClosedBet")]
        public List<Bets> ClosedBet(Roulettes roulettes)
        {
            _betService.ClosedBet(roulettes);
            return _betService.GetBetsByRoulette(roulettes);
        }
    }
}