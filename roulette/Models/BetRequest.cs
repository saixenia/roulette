namespace Roulette.Models
{
    public class BetRequest
    {
        private readonly int[] _bets;
        private readonly int _bet;
        private readonly double _amount;
        public BetRequest(int[] bets, double amount)
        {
            _bets = bets;
            _amount = amount;
        }
        public BetRequest(int bet, double amount)
        {
            _bet = bet;
            _amount = amount;
        }

    }
}
