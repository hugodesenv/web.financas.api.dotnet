using api.aspnetcore.webfinancas.Domain.Model;
using api.aspnetcore.webfinancas.Infrastructure.Interface;

namespace api.aspnetcore.webfinancas.Application.UseCase.Purpose
{
    public interface IPurposeInsertUseCase
    {
        Task<bool> Execute(Domain.Model.Purpose purpose);
    }

    public class InsertPurposeUseCase(IPurposeRepository purposeRepository) : IPurposeInsertUseCase
    {
        public async Task<bool> Execute(Domain.Model.Purpose purpose)
        {
            bool inserted = await purposeRepository.Insert(purpose);
            return inserted;
        }
    }
}
