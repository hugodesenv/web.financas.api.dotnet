using api.aspnetcore.webfinancas.Domain.Model;

namespace api.aspnetcore.webfinancas.Domain.Interface
{
    public interface IAccountRepository
    {
        Task<bool> save(Account account);
        Task<bool> auth(String username, String password);
    }
}
