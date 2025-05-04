using api.aspnetcore.webfinancas.Domain.Model;

namespace api.aspnetcore.webfinancas.Infrastructure.Interface
{
    public interface IAccountRepository
    {
        Task<bool> Save(Account account);
        Task<bool> Auth(string username, string password);
    }
}
