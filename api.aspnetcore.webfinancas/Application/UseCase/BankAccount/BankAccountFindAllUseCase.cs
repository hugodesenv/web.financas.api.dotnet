using api.aspnetcore.webfinancas.Application.DTO.BankAccount;
using api.aspnetcore.webfinancas.Infrastructure.Interface;

namespace api.aspnetcore.webfinancas.Application.UseCase.BankAccount
{
    public interface IBankAccountFindAllUseCase
    {
        Task<List<BankAccountFindAllDTO>> Execute();
    }

    public class BankAccountFindAllUseCase(IBankAccountRepository repository) : IBankAccountFindAllUseCase
    {
        public async Task<List<BankAccountFindAllDTO>> Execute()
        {
            List<BankAccountFindAllDTO> banks = await repository.FindAll();

            return [.. banks.OrderBy(p => p.id)];
        }
    }
}
