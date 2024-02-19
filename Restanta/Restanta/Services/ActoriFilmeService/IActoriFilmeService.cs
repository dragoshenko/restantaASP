using Restanta.Models.Dtos;

namespace Restanta.Services.ActoriFilmeService
{
    public interface IActoriFilmeService
    {
        Task<List<ActoriFilmeDto>> GetAllActoriFilme();
        Task<ActoriFilmeDto> GetActoriFilmeById(Guid actoriFilmeId);
        Task CreateActoriFilme(ActoriFilmeDto actoriFilmeDto);
        Task UpdateActoriFilme(Guid actoriFilmeId, ActoriFilmeDto actoriFilmeDto);
        Task DeleteActoriFilme(Guid actoriFilmeId);
    }

}
