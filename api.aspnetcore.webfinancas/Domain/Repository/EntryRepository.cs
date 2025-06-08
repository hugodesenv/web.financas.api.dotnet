using api.aspnetcore.webfinancas.Application.DTO.Entry;
using api.aspnetcore.webfinancas.Domain.Model;
using api.aspnetcore.webfinancas.Infrastructure.Interface;

namespace api.aspnetcore.webfinancas.Domain.Repository
{
    public class EntryRepository(DatabaseContext database) : IEntryRepository
    {
        public async Task<bool> Insert(EntryInsertDTO dto)
        {
            Entry entry = new()
            {
                person_id = dto.person_id,
                type = dto.type,
                issue_date = dto.issue_date,
                purpose_id = dto.purpose_id,
                observation = dto.observation,
                mode = dto.mode
            };

            database.Entry.Add(entry);

            int iRowAffected = await database.SaveChangesAsync();

            return iRowAffected > 0;
        }
    }
}
