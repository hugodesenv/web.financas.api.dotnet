using api.aspnetcore.webfinancas.Infrastructure.Interface;

namespace api.aspnetcore.webfinancas.Application.UseCase.Purpose
{
    using api.aspnetcore.webfinancas.Application.DTO.Purpose;
    using api.aspnetcore.webfinancas.Domain.Model;

    public interface IPurposeUpdateUseCase
    {
        Task<bool> Execute(PurposeUpdateDTO purpose, int id);
    }

    public class PurposeUpdateUseCase(IPurposeRepository purposeRepository) : IPurposeUpdateUseCase
    {
        public async Task<bool> Execute(PurposeUpdateDTO purpose, int id)
        {
            bool updated = await purposeRepository.Update(purpose, id);
            return updated;
        }
    }
}
