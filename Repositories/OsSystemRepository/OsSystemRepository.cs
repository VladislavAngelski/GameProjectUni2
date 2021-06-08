using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.OsSystemRepository
{
    public class OsSystemRepository : IOsSystemRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public OsSystemRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<OsSystem> GetAllOsSystems => _appDbContext.OsSystems.Include(x => x.Games)
                                                                               .ToList();
        public OsSystem GetOsSystemById(int id) => _appDbContext.OsSystems
                                                                          .AsNoTracking()
                                                                          .SingleOrDefault(x => x.Id == id);
    }
}
