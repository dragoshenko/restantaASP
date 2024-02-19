using Microsoft.AspNetCore.Mvc;
using Restanta.Models.Dtos;
using Restanta.Services.FilmService;

namespace Restanta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmService _filmService;

        public FilmController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFilms()
        {
            var films = await _filmService.GetAllFilms();
            return Ok(films);
        }

        [HttpGet("{filmId}")]
        public async Task<IActionResult> GetFilmById([FromRoute] Guid filmId)
        {
            var film = await _filmService.GetFilmById(filmId);

            if (film == null)
            {
                return NotFound();
            }

            return Ok(film);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFilm([FromBody] FilmDto filmDto)
        {
            await _filmService.CreateFilm(filmDto);
            return Ok();
        }

        [HttpPut("{filmId}")]
        public async Task<IActionResult> UpdateFilm([FromRoute] Guid filmId, [FromBody] FilmDto filmDto)
        {
            await _filmService.UpdateFilm(filmId, filmDto);
            return Ok();
        }

        [HttpDelete("{filmId}")]
        public async Task<IActionResult> DeleteFilm([FromRoute] Guid filmId)
        {
            await _filmService.DeleteFilm(filmId);
            return Ok();
        }
    }

}
