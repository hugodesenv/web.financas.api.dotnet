using api.aspnetcore.webfinancas.Application.DTO.Entry;

namespace api.aspnetcore.webfinancas.Infrastructure.Interface
{
    public interface IEntryRepository
    {
        Task<bool> Insert(EntryInsertDTO dto);
    }
}