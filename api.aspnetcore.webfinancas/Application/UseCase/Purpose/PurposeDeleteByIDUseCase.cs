using api.aspnetcore.webfinancas.Infrastructure.Interface;

namespace api.aspnetcore.webfinancas.Application.UseCase.Purpose
{
    public interface IPurposeDeleteByIDUseCase
    {
        Task<bool> Execute(int id);
    }

    public class PurposeDeleteByIDUseCase(IPurposeRepository repository) : IPurposeDeleteByIDUseCase
    {
        public async Task<bool> Execute(int id)
        {
            var purpose = await repository.FindByID(id) ?? throw new Exception("Purpose not found");
            bool success = repository.DeleteById(id);

            return success;
        }
    }
}
