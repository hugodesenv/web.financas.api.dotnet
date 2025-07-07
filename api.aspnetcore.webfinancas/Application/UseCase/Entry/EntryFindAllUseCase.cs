namespace api.aspnetcore.webfinancas.Application.UseCase.Entry
{
    using api.aspnetcore.webfinancas.Application.DTO.Entry;
    using api.aspnetcore.webfinancas.Infrastructure.Interface;

    public interface IEntryFindAllUseCase
    {
        Task<List<EntryFindAllDTO>> Execute(EntryFindAllRequestDTO param);
    }

    public class EntryFindAllUseCase(IEntryRepository repository) : IEntryFindAllUseCase
    {
        public async Task<List<EntryFindAllDTO>> Execute(EntryFindAllRequestDTO param)
        {
            return await repository.FindAll(param);
        }
    }
}
