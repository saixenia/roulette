using Roulette.Models;
using System.Collections.Generic;

namespace Roulette.Interfaces
{
    public interface IRouletteService
    {
        List<Roulettes> GetRoulettesCreated();
        int CreateRoulette();
        bool OpenRoulette(Roulettes roulette);
        Roulettes GetFirstOpenedRoulette();
        void CloseRoullete(Roulettes roulettes);
    }
}