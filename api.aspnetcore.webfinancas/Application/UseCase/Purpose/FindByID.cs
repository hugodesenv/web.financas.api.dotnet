using api.aspnetcore.webfinancas.Infrastructure.Repository;

namespace api.aspnetcore.webfinancas.Application.UseCase.Purpose
{
    public interface IPurposeFindByID
    {
        Task<Domain.Model.Purpose?> Execute(int id);
    }

    public class PurposeFindByID(PurposeRepository purposeRepository) : IPurposeFindByID
    {
        public async Task<Domain.Model.Purpose?> Execute(int id)
        {
            var purpose = await purposeRepository.FindByID(id);
            return purpose;
        }
    }
}
