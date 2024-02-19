using Restanta.Data;
using Restanta.Models;
using Restanta.Repositories.GenericRepository;

namespace Restanta.Repositories.FilmRepository
{
    public class FilmRepository : GenericRepository<Film>, IFilmRepository
    {
        public FilmRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
