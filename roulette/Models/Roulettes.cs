using System.ComponentModel.DataAnnotations;

namespace Roulette.Models
{
    public class Roulettes
    {
        [Key]
        public int RouletteId { get; set; }
        public bool Open { get; set; }
    }
}
