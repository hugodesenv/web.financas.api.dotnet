namespace api.aspnetcore.webfinancas.Application.UseCase.BankAccount
{
    using api.aspnetcore.webfinancas.Application.DTO.BankAccount;
    using api.aspnetcore.webfinancas.Infrastructure.Interface;

    public interface IBankAccountFindByID
    {
        Task<BankAccountFindByIDDTO?> Execute(int id);
    }

    public class BankAccountFindByID(IBankAccountRepository repository) : IBankAccountFindByID
    {
        public async Task<BankAccountFindByIDDTO?> Execute(int id)
        {
            var bank = await repository.FindByID(id);
            return bank;
        }
    }
}
