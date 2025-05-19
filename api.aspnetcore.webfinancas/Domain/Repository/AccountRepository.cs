using api.aspnetcore.webfinancas.Domain.Model;
using api.aspnetcore.webfinancas.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace api.aspnetcore.webfinancas.Domain.Repository
{
    public class AccountRepository(DatabaseContext database) : IAccountRepository
    {
        public async Task<bool> Auth(string username, string password)
        {
           try
            {
                Account? account = await database.Accounts.Where(acc => acc.username == username && acc.password == password && acc.active == true).FirstAsync();
                return account != null;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return false;
            }
        }

        public async Task<bool> Save(Account account)
        {
            database.Accounts.Add(account);
            int rowsAffected = await database.SaveChangesAsync();

            return rowsAffected > 0;
        }
    }
}
