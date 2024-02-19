using Microsoft.AspNetCore.Mvc;
using Restanta.Models.Dtos;
using Restanta.Services.ActoriFilmeService;

namespace Restanta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActoriFilmeController : ControllerBase
    {
        private readonly IActoriFilmeService _actoriFilmeService;

        public ActoriFilmeController(IActoriFilmeService actoriFilmeService)
        {
            _actoriFilmeService = actoriFilmeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllActoriFilme()
        {
            var actoriFilme = await _actoriFilmeService.GetAllActoriFilme();
            return Ok(actoriFilme);
        }

        [HttpGet("{actoriFilmeId}")]
        public async Task<IActionResult> GetActoriFilmeById([FromRoute] Guid actoriFilmeId)
        {
            var actoriFilme = await _actoriFilmeService.GetActoriFilmeById(actoriFilmeId);

            if (actoriFilme == null)
            {
                return NotFound();
            }

            return Ok(actoriFilme);
        }

        [HttpPost]
        public async Task<IActionResult> CreateActoriFilme([FromBody] ActoriFilmeDto actoriFilmeDto)
        {
            await _actoriFilmeService.CreateActoriFilme(actoriFilmeDto);
            return Ok();
        }

        [HttpPut("{actoriFilmeId}")]
        public async Task<IActionResult> UpdateActoriFilme([FromRoute] Guid actoriFilmeId, [FromBody] ActoriFilmeDto actoriFilmeDto)
        {
            await _actoriFilmeService.UpdateActoriFilme(actoriFilmeId, actoriFilmeDto);
            return Ok();
        }

        [HttpDelete("{actoriFilmeId}")]
        public async Task<IActionResult> DeleteActoriFilme([FromRoute] Guid actoriFilmeId)
        {
            await _actoriFilmeService.DeleteActoriFilme(actoriFilmeId);
            return Ok();
        }
    }

}
