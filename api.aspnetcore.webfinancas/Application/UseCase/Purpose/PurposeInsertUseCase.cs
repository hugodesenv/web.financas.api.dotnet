using api.aspnetcore.webfinancas.Infrastructure.Interface;

namespace api.aspnetcore.webfinancas.Application.UseCase.Purpose
{
    using api.aspnetcore.webfinancas.Domain.Model;

    public interface IPurposeInsertUseCase
    {
        Task<bool> Execute(Purpose purpose);
    }

    public class InsertPurposeUseCase(IPurposeRepository purposeRepository) : IPurposeInsertUseCase
    {
        public async Task<bool> Execute(Purpose purpose)
        {
            bool inserted = await purposeRepository.Insert(purpose);
            return inserted;
        }
    }
}
