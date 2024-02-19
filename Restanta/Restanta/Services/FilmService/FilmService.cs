using AutoMapper;
using Restanta.Models.Dtos;
using Restanta.Models;
using Restanta.Repositories.FilmRepository;

namespace Restanta.Services.FilmService
{
    public class FilmService : IFilmService
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;

        public FilmService(IFilmRepository filmRepository, IMapper mapper)
        {
            _filmRepository = filmRepository;
            _mapper = mapper;
        }

        public async Task<List<FilmDto>> GetAllFilms()
        {
            var films = await _filmRepository.GetAllAsync();
            return _mapper.Map<List<FilmDto>>(films);
        }

        public async Task<FilmDto> GetFilmById(Guid filmId)
        {
            var film = await _filmRepository.FindByIdAsync(filmId);
            return _mapper.Map<FilmDto>(film);
        }

        public async Task CreateFilm(FilmDto filmDto)
        {
            var film = _mapper.Map<Film>(filmDto);
            _filmRepository.Create(film);
            await _filmRepository.SaveAsync();
        }

        public async Task UpdateFilm(Guid filmId, FilmDto filmDto)
        {
            var existingFilm = await _filmRepository.FindByIdAsync(filmId);
            if (existingFilm == null)
            {
                throw new InvalidOperationException($"Filmul cu ID-ul {filmId} nu există.");
            }

            _mapper.Map(filmDto, existingFilm);
            _filmRepository.Update(existingFilm);
            await _filmRepository.SaveAsync();
        }

        public async Task DeleteFilm(Guid filmId)
        {
            var film = await _filmRepository.FindByIdAsync(filmId);
            if (film != null)
            {
                _filmRepository.Delete(film);
                await _filmRepository.SaveAsync();
            }
        }
    }

}
