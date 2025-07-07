namespace api.aspnetcore.webfinancas.Infrastructure.Interface
{
    using api.aspnetcore.webfinancas.Application.DTO.Entry;

    public interface IEntryRepository
    {
        Task<bool> Insert(EntryInsertDTO dto);
        Task<List<EntryFindAllDTO>> FindAll(EntryFindAllRequestDTO param);
    }
}