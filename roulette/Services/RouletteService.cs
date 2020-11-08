using Roulette.Interfaces;
using Roulette.Models;
using System.Collections.Generic;
using System.Linq;

namespace Roulette.Services
{
    public class RouletteService:IRouletteService
    {
        private readonly RouletteContext context;

        public RouletteService(RouletteContext context)
        {
            this.context = context;
        }

        public List<Roulettes> GetRoulettesCreated()
        {
            return context.Roulettes.ToList();
        }

        public int CreateRoulette()
        {
            var roulette = new Roulettes()
            {
                Open = false
            };
            context.Roulettes.Add(roulette);
            context.SaveChanges();

            return roulette.RouletteId;
        }

        public bool OpenRoulette(Roulettes roulette)
        {
            var result = context.Roulettes.Where(r => r.RouletteId == roulette.RouletteId && !r.Open).SingleOrDefault();
            if (result == null)
            {
                return false;
            }
            
            result.Open = true;
            context.SaveChanges();

            return true;
        }
    }
}