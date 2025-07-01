using api.aspnetcore.webfinancas.Application.DTO.Entry;
using api.aspnetcore.webfinancas.Domain.Model;
using api.aspnetcore.webfinancas.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace api.aspnetcore.webfinancas.Domain.Repository
{
    public class EntryRepository(DatabaseContext database) : IEntryRepository
    {
        public async Task<List<EntryFindAllDTO>> FindAll()
        {
            var query = await database.Entry.Select(x => new EntryFindAllDTO()
            {
                id = x.id,
                issueDate = x.issue_date,
                mode = x.mode,
                observation = x.observation,
                personID = x.person_id,
                personName = x.person.name,
                purposeDescription = x.purpose.description,
                purposeID = x.purpose_id,
                type = x.type
            }).ToListAsync();

            return query;
        }

        public async Task<bool> Insert(EntryInsertDTO dto)
        {
            Entry entry = new()
            {
                person_id = dto.person_id,
                type = dto.type,
                issue_date = dto.issue_date,
                purpose_id = dto.purpose_id,
                observation = dto.observation,
                mode = dto.mode,
                bank_account_id = dto.bank_account_id,
                total = dto.total
            };

            database.Entry.Add(entry);

            int iRowAffected = await database.SaveChangesAsync();

            return iRowAffected > 0;
        }
    }
}
