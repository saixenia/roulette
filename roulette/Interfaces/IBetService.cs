using Roulette.Models;
using System.Collections.Generic;

namespace Roulette.Interfaces
{
    public interface IBetService
    {
        bool ValidateBet(Bets bets);
        void ClosedBet(Roulettes roulettes);
        List<Bets> GetBetsByRoulette(Roulettes roulettes);
    }
}