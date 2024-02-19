using Restanta.Models.Dtos;

namespace Restanta.Services.FilmService
{
    public interface IFilmService
    {
        Task<List<FilmDto>> GetAllFilms();
        Task<FilmDto> GetFilmById(Guid filmId);
        Task CreateFilm(FilmDto filmDto);
        Task UpdateFilm(Guid filmId, FilmDto filmDto);
        Task DeleteFilm(Guid filmId);
    }

}
