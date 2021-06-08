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
    public class GameRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public GameRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void Add(Game game)
        {
            _appDbContext.Games.Add(game);
            _appDbContext.SaveChanges();

        }
        public void Update(Game game)
        {
            var oldGame = _appDbContext.Games.Single(x => x.Id == game.Id);
            oldGame.Model = game.Model;
            oldGame.Year = game.Year;
            oldGame.SystemId = game.SystemId;
            _appDbContext.Entry(oldGame).State = EntityState.Modified;
            //_appDbContext.Games.Update(game);
            _appDbContext.SaveChanges();

        }
    }
}
