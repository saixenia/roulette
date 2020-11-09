using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Roulette.Models
{
    public class Bets
    {
        [Key]
        public int BetId { get; set; }
        [Range(0, 36)]
        public int BetNumber { get; set; }
        public string BetColor { get; set; }
        [Range(1.00, 10000.00)]
        public double BetAmount { get; set; }
        public int RouletteId { get; set; }
        [ForeignKey("RouletteId")]
        public Roulettes Roulettes { get; set; }
    }
}
