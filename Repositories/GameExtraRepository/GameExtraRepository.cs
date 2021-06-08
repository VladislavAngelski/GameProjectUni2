using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.GameExtraRepository
{
    public class GameExtraRepository : IGameExtraRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public GameExtraRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void Add(GameExtra gameextra)
        {
            _appDbContext.Entry(gameextra).State = EntityState.Detached;
            _appDbContext.GameExtras.Add(gameextra);
            _appDbContext.SaveChanges();
        }
        public ICollection<GameExtra> GetGameExtras(int gameId) => _appDbContext.GameExtras.Include(x => x.Game)
                                                                                      .Include(x => x.Extra)
                                                                                      .Where(x => x.GameId == gameId).ToList();
    }
}
