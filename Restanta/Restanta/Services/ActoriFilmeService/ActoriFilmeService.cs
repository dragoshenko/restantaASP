using AutoMapper;
using Restanta.Models;
using Restanta.Models.Dtos;
using Restanta.Repositories.ActoriFilmeRepository;

namespace Restanta.Services.ActoriFilmeService
{
    public class ActoriFilmeService : IActoriFilmeService
    {
        private readonly IActoriFilmeRepository _actoriFilmeRepository;
        private readonly IMapper _mapper;

        public ActoriFilmeService(IActoriFilmeRepository actoriFilmeRepository, IMapper mapper)
        {
            _actoriFilmeRepository = actoriFilmeRepository;
            _mapper = mapper;
        }

        public async Task<List<ActoriFilmeDto>> GetAllActoriFilme()
        {
            var actoriFilme = await _actoriFilmeRepository.GetAllAsync();
            return _mapper.Map<List<ActoriFilmeDto>>(actoriFilme);
        }

        public async Task<ActoriFilmeDto> GetActoriFilmeById(Guid actoriFilmeId)
        {
            var actoriFilme = await _actoriFilmeRepository.FindByIdAsync(actoriFilmeId);
            return _mapper.Map<ActoriFilmeDto>(actoriFilme);
        }

        public async Task CreateActoriFilme(ActoriFilmeDto actoriFilmeDto)
        {
            var actoriFilme = _mapper.Map<ActoriFilme>(actoriFilmeDto);
            _actoriFilmeRepository.Create(actoriFilme);
            await _actoriFilmeRepository.SaveAsync();
        }

        public async Task UpdateActoriFilme(Guid actoriFilmeId, ActoriFilmeDto actoriFilmeDto)
        {
            var existingActoriFilme = await _actoriFilmeRepository.FindByIdAsync(actoriFilmeId);
            if (existingActoriFilme == null)
            {
                throw new InvalidOperationException($"ActoriFilme-ul cu ID-ul {actoriFilmeId} nu există.");
            }

            _mapper.Map(actoriFilmeDto, existingActoriFilme);
            _actoriFilmeRepository.Update(existingActoriFilme);
            await _actoriFilmeRepository.SaveAsync();
        }

        public async Task DeleteActoriFilme(Guid actoriFilmeId)
        {
            var actoriFilme = await _actoriFilmeRepository.FindByIdAsync(actoriFilmeId);
            if (actoriFilme != null)
            {
                _actoriFilmeRepository.Delete(actoriFilme);
                await _actoriFilmeRepository.SaveAsync();
            }
        }
    }


}
