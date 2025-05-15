using api.aspnetcore.webfinancas.Domain.Model;
using api.aspnetcore.webfinancas.Infrastructure.Interface;

public interface IPurposeFindByIDUseCase
{
    Task<Purpose?> Execute(int id);
}

namespace api.aspnetcore.webfinancas.Application.UseCase.Purpose
{

    public class PurposeFindByID(IPurposeRepository purposeRepository) : IPurposeFindByIDUseCase
    {
        async Task<Domain.Model.Purpose?> IPurposeFindByIDUseCase.Execute(int id)
        {
            var purpose = await purposeRepository.FindByID(id);
            return purpose;
        }
    }
}
