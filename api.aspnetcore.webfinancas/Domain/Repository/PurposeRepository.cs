using api.aspnetcore.webfinancas.Application.DTO.Purpose;
using api.aspnetcore.webfinancas.Domain.Model;
using api.aspnetcore.webfinancas.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace api.aspnetcore.webfinancas.Domain.Repository
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

        public async Task<Purpose?> FindByID(int id)
        {
            try
            {
                Purpose? purpose = await database.Purpose.Where(x => x.id == id).FirstAsync();
                return purpose;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> Insert(Purpose purpose)
        {
            await database.Purpose.AddAsync(purpose);
            int rowsAffected = await database.SaveChangesAsync();

            return rowsAffected > 0;    
        }
    }
}
