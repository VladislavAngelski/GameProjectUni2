using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.GameRepository
{
    public interface IGameRepository
    {
        Game GetGameById(int id);
        Game GetGameByModel(string model);
        IEnumerable<Game> GetAllGames { get; }
        void Add(Game game);
        void Update(Game game);
        void Delete(int game);
    }
}
