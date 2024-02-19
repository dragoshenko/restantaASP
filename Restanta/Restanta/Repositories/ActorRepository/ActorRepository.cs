using Restanta.Data;
using Restanta.Models;
using Restanta.Repositories.FilmRepository;
using Restanta.Repositories.GenericRepository;

namespace Restanta.Repositories.ActorRepository
{
    public class ActorRepository : GenericRepository<Actor>, IActorRepository
    {
        public ActorRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
