using api.aspnetcore.webfinancas.Application.DTO.BankAccount;
using api.aspnetcore.webfinancas.Domain.Model;
using api.aspnetcore.webfinancas.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace api.aspnetcore.webfinancas.Domain.Repository
{
    public class BankAccountRepository(DatabaseContext database) : IBankAccountRepository
    {
        public async Task<List<BankAccountFindAllDTO>> FindAll()
        {
            var banks = await database.BankAccount.Select(x => new BankAccountFindAllDTO()
            {
                id = x.id,
                description = x.description,
            }).ToListAsync();

            return banks;
        }

        public async Task<BankAccountFindByIDDTO> FindByID(int id)
        {
            Console.Write("UASHDUHASUDHAUSD");
            Console.Write(id);
            var bank = await database.BankAccount.Select(x => new BankAccountFindByIDDTO()
            {
                id = x.id,
                description = x.description
            }).FirstAsync(x => x.id == id);

            return bank; 
        }

        public async Task<bool> Insert(BankAccountInsertDTO dto)
        {
            await database.BankAccount.AddAsync(new BankAccount()
            {
                description = dto.description
            });

            int iRowAffected = await database.SaveChangesAsync();

            return iRowAffected > 0; 
        }

        public async Task<bool> Update(BankAccountUpdateDTO dto)
        {
            var bank = await database.BankAccount.SingleAsync(x => x.id == dto.id);
            bank.description = dto.description;
    
            int iRowAffected = await database.SaveChangesAsync();
            
            return iRowAffected > 0;
        }
    }
}
