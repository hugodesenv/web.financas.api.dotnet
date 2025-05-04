using api.aspnetcore.webfinancas.Application.DTO.Purpose;
using api.aspnetcore.webfinancas.Domain.Model;
using api.aspnetcore.webfinancas.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace api.aspnetcore.webfinancas.Infrastructure.Repository
{
    public class PurposeRepository(DatabaseContext database) : IPurposeRepository
    {
        public async Task<List<PurposeFindAllDTO>> FindAll()
        {
            var purposes = await database.Purpose.Select(x => new PurposeFindAllDTO() {
                id = x.id,
                description = x.description
            }).ToListAsync();

            return purposes;
        }
    }
}
