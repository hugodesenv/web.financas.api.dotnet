namespace api.aspnetcore.webfinancas.Application.UseCase.BankAccount
{
    using api.aspnetcore.webfinancas.Application.DTO.BankAccount;
    using api.aspnetcore.webfinancas.Infrastructure.Interface;

    public interface IBankAccountFindByIDUseCase
    {
        Task<BankAccountFindByIDDTO?> Execute(int id);
    }

    public class BankAccountFindByIDUseCase(IBankAccountRepository repository) : IBankAccountFindByIDUseCase
    {
        public async Task<BankAccountFindByIDDTO?> Execute(int id)
        {
            var bank = await repository.FindByID(id);
            return bank;
        }
    }
}
