using Microsoft.Extensions.Logging;
using Roulette.Interfaces;
using Roulette.Models;
using System.Collections.Generic;
using System.Linq;

namespace Roulette.Services
{
    public class BetService : IBetService
    {
        private readonly ILogger _logger;
        private readonly IRouletteService _rouletteService;

        private readonly RouletteContext _context;
        private BetRequest _betRequest;

        private readonly int[] red = new int[] { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36 };
        private readonly int[] black = new int[] { 3, 5, 7, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31, 33, 35 };
        public BetService(IRouletteService rouletteService, RouletteContext context, ILogger<BetService> logger)
        {
            _rouletteService = rouletteService;
            _context = context;
            _logger = logger;
        }

        public bool ValidateBet(Bets bets)
        {
            if (!string.IsNullOrEmpty(bets.BetColor))
            {
               return ValidateBetColor(bets);
            }

            return SendBet(new BetRequest(bets.BetNumber, bets.BetAmount), bets);
        }

        public bool ValidateBetColor(Bets bets)
        {
            if (bets.BetColor.ToUpper() == "BLACK")
            {

               return SendBet(new BetRequest(black, bets.BetAmount), bets);
            }

            return SendBet(new BetRequest(red, bets.BetAmount), bets);
        }

        public bool SendBet(BetRequest betRequest, Bets bets)
        {
            var rouletteOpen = _rouletteService.GetFirstOpenedRoulette();
            if (rouletteOpen == null)
            {

                return false;
            }
            bets.RouletteId = rouletteOpen.RouletteId;
            bets.Roulettes = rouletteOpen;
            _context.Bets.Add(bets);
            _context.SaveChanges();

            return true;
        }

        public void ClosedBet(Roulettes roulettes)
        {
            _rouletteService.CloseRoullete(roulettes);

        }

        public List<Bets> GetBetsByRoulette(Roulettes roulettes)
        {
            return _context.Bets.Where(b => b.Roulettes.RouletteId == roulettes.RouletteId).ToList();
        }
    }
}