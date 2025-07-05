using api.aspnetcore.webfinancas.Application.DTO.BankAccount;
using api.aspnetcore.webfinancas.Infrastructure.Interface;

namespace api.aspnetcore.webfinancas.Application.UseCase.BankAccount
{
    public interface IBankAccountUpdateUseCase
    {
        Task<bool> Execute(BankAccountUpdateDTO dto);
    }

    public class BankAccountUpdateUseCase(IBankAccountRepository repository) : IBankAccountUpdateUseCase
    {
        public async Task<bool> Execute(BankAccountUpdateDTO dto)
        {
            bool success = await repository.Update(dto);
            return success;
        }
    }
}
