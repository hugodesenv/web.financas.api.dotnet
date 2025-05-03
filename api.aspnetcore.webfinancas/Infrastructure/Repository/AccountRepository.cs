using api.aspnetcore.webfinancas.Domain.Interface;
using api.aspnetcore.webfinancas.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace api.aspnetcore.webfinancas.Infrastructure.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DatabaseContext _database;

        public AccountRepository(DatabaseContext database)
        {
            _database = database;
        }

        public async Task<bool> auth(string username, string password)
        {
           try
            {
                Account? account = await _database.Accounts.Where(acc => acc.username == username && acc.password == password && acc.active == true).FirstAsync();
                return account != null;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> save(Account account)
        {
            _database.Accounts.Add(account);
            int rowsAffected = await _database.SaveChangesAsync();

            return rowsAffected > 0;
        }
    }
}
