using api.aspnetcore.webfinancas.Application.DTO.Entry;
using api.aspnetcore.webfinancas.Domain.Model;
using api.aspnetcore.webfinancas.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace api.aspnetcore.webfinancas.Domain.Repository
{
    public class EntryRepository(DatabaseContext database) : IEntryRepository
    {
        public async Task<List<EntryFindAllDTO>> FindAll(EntryFindAllRequestDTO param)
        {
            var query = database.Entry.Select(x => new EntryFindAllDTO()
            {
                id = x.id,
                issue_date = x.issue_date,
                type = x.type,
                person_id = x.person_id,
                person_name = x.person.name,
                purpose_id = x.purpose_id,
                purpose_description = x.purpose.description,
                mode = x.mode,
                bank_account_id = x.bank_account_id,
                bank_account_description = x.bankAccount.description,
                total = x.total,
            }).AsQueryable();

            if (param.initial_issue_date.HasValue && param.final_issue_date.HasValue)
            {
                query = query.Where(x => x.issue_date >= param.initial_issue_date
                    && x.issue_date <= param.final_issue_date);
            }

            return await query.ToListAsync();
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
