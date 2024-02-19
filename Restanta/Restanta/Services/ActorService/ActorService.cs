using AutoMapper;
using Restanta.Models.Dtos;
using Restanta.Models;
using Restanta.Repositories.ActorRepository;

namespace Restanta.Services.ActorService
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;
        private readonly IMapper _mapper;

        public ActorService(IActorRepository actorRepository, IMapper mapper)
        {
            _actorRepository = actorRepository;
            _mapper = mapper;
        }

        public async Task<List<ActorDto>> GetAllActors()
        {
            var actors = await _actorRepository.GetAllAsync();
            return _mapper.Map<List<ActorDto>>(actors);
        }

        public async Task<ActorDto> GetActorById(Guid actorId)
        {
            var actor = await _actorRepository.FindByIdAsync(actorId);
            return _mapper.Map<ActorDto>(actor);
        }

        public async Task CreateActor(ActorDto actorDto)
        {
            var actor = _mapper.Map<Actor>(actorDto);
            _actorRepository.Create(actor);
            await _actorRepository.SaveAsync();
        }

        public async Task UpdateActor(Guid actorId, ActorDto actorDto)
        {
            var existingActor = await _actorRepository.FindByIdAsync(actorId);
            if (existingActor == null)
            {
                throw new InvalidOperationException($"Actorul cu ID-ul {actorId} nu există.");
            }

            _mapper.Map(actorDto, existingActor);
            _actorRepository.Update(existingActor);
            await _actorRepository.SaveAsync();
        }

        public async Task DeleteActor(Guid actorId)
        {
            var actor = await _actorRepository.FindByIdAsync(actorId);
            if (actor != null)
            {
                _actorRepository.Delete(actor);
                await _actorRepository.SaveAsync();
            }
        }
    }

}
