using Restanta.Data;
using Restanta.Models;
using Restanta.Repositories.FilmRepository;
using Restanta.Repositories.GenericRepository;

namespace Restanta.Repositories.ActoriFilmeRepository
{
    public class ActoriFilmeRepository : GenericRepository<ActoriFilme>, IActoriFilmeRepository
    {
        public ActoriFilmeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
