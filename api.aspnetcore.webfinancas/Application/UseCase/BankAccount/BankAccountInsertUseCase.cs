using api.aspnetcore.webfinancas.Application.DTO.BankAccount;
using api.aspnetcore.webfinancas.Infrastructure.Interface;

namespace api.aspnetcore.webfinancas.Application.UseCase.BankAccount
{
    public interface IBankAccountInsertUseCase
    {
        Task<bool> Execute(BankAccountInsertDTO purpose);
    }

    public class BankAccountInsertUseCase(IBankAccountRepository repository) : IBankAccountInsertUseCase
    {
        public async Task<bool> Execute(BankAccountInsertDTO bankAccount)
        {
            bool success =  await repository.Insert(bankAccount);
            return success;
        }
    }
}
