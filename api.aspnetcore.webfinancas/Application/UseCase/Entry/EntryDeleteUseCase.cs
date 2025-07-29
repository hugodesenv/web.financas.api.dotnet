using api.aspnetcore.webfinancas.Infrastructure.Interface;

namespace api.aspnetcore.webfinancas.Application.UseCase.Entry
{
    public interface IEntryDeleteUseCase
    {
        Task<bool> Execute(int id);
    }

    public class EntryDeleteUseCase(IEntryRepository repository) : IEntryDeleteUseCase
    {
        public async Task<bool> Execute(int id)
        {
            if (id <= 0)
            {
                throw new Exception("ID must be grather than zero");
            }

            return await repository.Delete(id);
        }
    }
}
