using Microsoft.EntityFrameworkCore;

namespace Roulette.Models
{
    public class RouletteContext : DbContext
    {
        public RouletteContext(DbContextOptions<RouletteContext> options)
            : base(options)
        {
        }

        public DbSet<Roulettes> Roulettes { get; set; }
    }
}
