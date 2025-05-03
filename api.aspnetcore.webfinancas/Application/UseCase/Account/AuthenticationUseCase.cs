using api.aspnetcore.webfinancas.Application.DTO;
using api.aspnetcore.webfinancas.Domain.Interface;
using api.aspnetcore.webfinancas.Domain.Model;
using api.aspnetcore.webfinancas.Infrastructure.Repository;

namespace api.aspnetcore.webfinancas.Application.UseCase.Account
{
    public class AuthenticationUseCase
    {
        private readonly IAccountRepository _accountRepository;

        public AuthenticationUseCase(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<bool> execute(AuthenticationDTO pAccount)
        {
            bool isAuthenticated = await _accountRepository.auth(pAccount.username, pAccount.password);
            return isAuthenticated;
        }
    }
}
