using api.aspnetcore.webfinancas.Application.DTO;
using api.aspnetcore.webfinancas.Domain.Interface;

namespace api.aspnetcore.webfinancas.Application.UseCase.Account
{
    public interface IAuthenticationUseCase
    {
        Task<bool> execute(AuthenticationDTO pAccount);
    }

    public class AuthenticationUseCase(IAccountRepository accountRepository) : IAuthenticationUseCase
    {
    
        public async Task<bool> execute(AuthenticationDTO pAccount)
        {
            bool isAuthenticated = await accountRepository.auth(pAccount.username, pAccount.password);
            return isAuthenticated;
        }
    }
}
