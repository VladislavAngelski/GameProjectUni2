using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.GameRepository
{
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public GameRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Game> GetAllGames => _appDbContext.Games.Include(x => x.OsSystem)
                                                                   .Include(x => x.GamesExtras).ThenInclude(x => x.Extra)
                                                                   .AsNoTracking().ToList();
        public Game GetGameById(int id) => _appDbContext.Games.Include(x => x.OsSystem)
                                                              .Include(x => x.GamesExtras).ThenInclude(x => x.Extra)
                                                              .AsNoTracking().SingleOrDefault(x => x.Id == id);
        public Game GetGameByModel(string model) => _appDbContext.Games.Include(b => b.OsSystem)
                                                                       .Include(x => x.GamesExtras)
                                                                       .ThenInclude(x => x.Extra)
                                                                       .AsNoTracking()
                                                                       .SingleOrDefault(x => x.Model == model);
        public int Add(Game game)
        {
            _appDbContext.Games.Add(game);
            _appDbContext.SaveChanges();
            return game.Id;

        }
        public void Update(Game game)
        {
            Game oldGame = _appDbContext.Games.Single(x => x.Id == game.Id);
            oldGame.Model = game.Model;
            oldGame.Year = game.Year;
            oldGame.SystemId = game.SystemId;
            _appDbContext.Entry(oldGame).State = EntityState.Modified;
            //_appDbContext.Games.Update(game);
            _appDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var game = _appDbContext.Games.Find(id);
            _appDbContext.Games.Remove(game);
            _appDbContext.SaveChanges();
        }
    }
}
