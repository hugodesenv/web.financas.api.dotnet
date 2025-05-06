using api.aspnetcore.webfinancas.Infrastructure.Repository;

namespace api.aspnetcore.webfinancas.Application.UseCase.Purpose
{
    public interface IPurposeFindByIDUseCase
    {
        Task<Domain.Model.Purpose?> Execute(int id);
    }

    public class PurposeFindByID(PurposeRepository purposeRepository) : IPurposeFindByIDUseCase
    {
        public async Task<Domain.Model.Purpose?> Execute(int id)
        {
            var purpose = await purposeRepository.FindByID(id);
            return purpose;
        }
    }
}
