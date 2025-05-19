using api.aspnetcore.webfinancas.Application.DTO.Purpose;
using api.aspnetcore.webfinancas.Infrastructure.Interface;

namespace api.aspnetcore.webfinancas.Application.UseCase.Purpose
{
    public interface IPurposeFindAllUseCase
    {
        Task<List<PurposeFindAllDTO>> Execute();
    }

    public class PurposeFindAllUseCase(IPurposeRepository purposeRepository): IPurposeFindAllUseCase
    {
        public async Task<List<PurposeFindAllDTO>> Execute()
        {
            List<PurposeFindAllDTO> purposes = await purposeRepository.FindAll();

            return [.. purposes.OrderBy(p => p.id)];
        }
    }
}
