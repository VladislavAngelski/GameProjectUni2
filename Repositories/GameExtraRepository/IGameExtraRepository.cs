using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.GameExtraRepository
{
    public interface IGameExtraRepository
    {
        void Add(GameExtra gameextra);
        ICollection<GameExtra> GetGameExtras(int gameId);
    }
}
