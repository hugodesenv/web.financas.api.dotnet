namespace api.aspnetcore.webfinancas.Application.UseCase.Entry
{
    using api.aspnetcore.webfinancas.Application.DTO.Entry;
    using api.aspnetcore.webfinancas.Infrastructure.Interface;

    public interface IEntryFindAllUseCase
    {
        Task<List<EntryFindAllDTO>> Execute();
    }

    public class EntryFindAllUseCase(IEntryRepository repository) : IEntryFindAllUseCase
    {
        public async Task<List<EntryFindAllDTO>> Execute()
        {
            return await repository.FindAll();
        }
    }
}
