using api.aspnetcore.webfinancas.Application.DTO.Entry;
using api.aspnetcore.webfinancas.Domain.Model;

namespace api.aspnetcore.webfinancas.Infrastructure.Interface
{
    public interface IEntryRepository
    {
        Task<bool> Insert(EntryInsertDTO dto);
        Task<List<EntryFindAllDTO>> FindAll();
    }
}