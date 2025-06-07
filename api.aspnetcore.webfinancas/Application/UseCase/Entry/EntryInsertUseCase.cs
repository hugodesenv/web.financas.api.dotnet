using api.aspnetcore.webfinancas.Application.DTO.Entry;
using api.aspnetcore.webfinancas.Infrastructure.Interface;

namespace api.aspnetcore.webfinancas.Application.UseCase.Entry
{
    public interface IEntryUseCase
    {
        Task<bool> Execute(EntryInsertDTO entry);
    }

    public class EntryInsertUseCase(IEntryRepository repository) : IEntryUseCase
    {
        public async Task<bool> Execute(EntryInsertDTO entry)
        {
            bool success = await repository.Insert(entry);
            return success;
        }
    }
}

//ToDo: Tratar enumerado.