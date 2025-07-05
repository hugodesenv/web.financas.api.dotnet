using api.aspnetcore.webfinancas.Application.DTO.Purpose;
using api.aspnetcore.webfinancas.Domain.Model;
using api.aspnetcore.webfinancas.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace api.aspnetcore.webfinancas.Domain.Repository
{
    public class PurposeRepository(DatabaseContext database) : IPurposeRepository
    {
        public bool DeleteById(int id)
        {
            var purpose = database.Purpose.SingleOrDefault(x => x.id == id);

            if (purpose == null)
                return false;

            database.Purpose.Remove(purpose);

            int iRowsAffected = database.SaveChanges();
            return iRowsAffected > 0;
        }

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

        public bool Update(PurposeUpdateDTO purpose)
        {
            Purpose? _purpose = database.Purpose.FirstOrDefault(x => x.id == purpose.id) ?? throw new Exception("Purpose not found");
            _purpose.description = purpose.description;
            int rowsAffected = database.SaveChanges();
            return rowsAffected > 0;    
        }
    }
}
