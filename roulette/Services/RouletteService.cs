using Microsoft.Extensions.Logging;
using Roulette.Interfaces;
using Roulette.Models;
using System.Collections.Generic;
using System.Linq;

namespace Roulette.Services
{
    public class RouletteService : IRouletteService
    {
        private readonly RouletteContext _context;
        private readonly ILogger _logger;
        public RouletteService(RouletteContext context, ILogger<RouletteService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<Roulettes> GetRoulettesCreated()
        {
            _logger.LogInformation("Listed Roulette");
            return _context.Roulettes.ToList();
        }

        public int CreateRoulette()
        {
            var roulette = new Roulettes()
            {
                Open = false
            };
            _context.Roulettes.Add(roulette);
            _context.SaveChanges();
            _logger.LogInformation("Created Roulette");
            return roulette.RouletteId;
        }

        public bool OpenRoulette(Roulettes roulette)
        {
            var result = _context.Roulettes.Where(r => r.RouletteId == roulette.RouletteId && !r.Open).SingleOrDefault();
            if (result == null)
            {
                _logger.LogInformation("RouletteId doesn't exist");
                return false;
            }

            result.Open = true;
            _context.SaveChanges();
            _logger.LogInformation("Opened Roulette");
            return true;
        }

        public Roulettes GetFirstOpenedRoulette()
        {
            return _context.Roulettes.Where(r => r.Open).FirstOrDefault();
        }

        public void CloseRoullete(Roulettes roulettes)
        {
            var roulette = _context.Roulettes.Where(r => r.RouletteId == roulettes.RouletteId).SingleOrDefault();
            _context.Roulettes.Update(roulette);
            _context.SaveChanges();
        }
    }
}