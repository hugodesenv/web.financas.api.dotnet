using api.aspnetcore.webfinancas.Application.DTO.Account;
using api.aspnetcore.webfinancas.Infrastructure.Interface;

namespace api.aspnetcore.webfinancas.Application.UseCase.Account
{
    public interface IAuthenticationUseCase
    {
        Task<bool> Execute(AccountAuthenticationDTO pAccount);
    }

    public class AuthenticationUseCase(IAccountRepository accountRepository) : IAuthenticationUseCase
    {
    
        public async Task<bool> Execute(AccountAuthenticationDTO pAccount)
        {
            bool isAuthenticated = await accountRepository.Auth(pAccount.username, pAccount.password);
            return isAuthenticated;
        }
    }
}
