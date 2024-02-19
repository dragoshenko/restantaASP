using Restanta.Models.Dtos;

namespace Restanta.Services.ActorService
{
    public interface IActorService
    {
        Task<List<ActorDto>> GetAllActors();
        Task<ActorDto> GetActorById(Guid actorId);
        Task CreateActor(ActorDto actorDto);
        Task UpdateActor(Guid actorId, ActorDto actorDto);
        Task DeleteActor(Guid actorId);
    }


}
