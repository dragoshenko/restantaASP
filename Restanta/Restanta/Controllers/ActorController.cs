using Microsoft.AspNetCore.Mvc;
using Restanta.Models.Dtos;
using Restanta.Services.ActorService;

namespace Restanta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;

        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllActors()
        {
            var actors = await _actorService.GetAllActors();
            return Ok(actors);
        }

        [HttpGet("{actorId}")]
        public async Task<IActionResult> GetActorById([FromRoute] Guid actorId)
        {
            var actor = await _actorService.GetActorById(actorId);

            if (actor == null)
            {
                return NotFound();
            }

            return Ok(actor);
        }

        [HttpPost]
        public async Task<IActionResult> CreateActor([FromBody] ActorDto actorDto)
        {
            await _actorService.CreateActor(actorDto);
            return Ok();
        }

        [HttpPut("{actorId}")]
        public async Task<IActionResult> UpdateActor([FromRoute] Guid actorId, [FromBody] ActorDto actorDto)
        {
            await _actorService.UpdateActor(actorId, actorDto);
            return Ok();
        }

        [HttpDelete("{actorId}")]
        public async Task<IActionResult> DeleteActor([FromRoute] Guid actorId)
        {
            await _actorService.DeleteActor(actorId);
            return Ok();
        }
    }

}
