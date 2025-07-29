using api.aspnetcore.webfinancas.Infrastructure.Interface;

namespace api.aspnetcore.webfinancas.Application.UseCase.BankAccount
{
    public interface IBankAccountDeleteUseCase
    {
        Task<bool> Execute(int id);
    }

    public class BankAccountDeleteUseCase(IBankAccountRepository repository) : IBankAccountDeleteUseCase
    {
        public async Task<bool> Execute(int id)
        {
            return await repository.Delete(id);
        }
    }
}
