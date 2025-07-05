using api.aspnetcore.webfinancas.Application.DTO.BankAccount;

namespace api.aspnetcore.webfinancas.Infrastructure.Interface
{
    public interface IBankAccountRepository
    {
        Task<List<BankAccountFindAllDTO>> FindAll();
        Task<bool> Insert(BankAccountInsertDTO dto);
        Task<BankAccountFindByIDDTO> FindByID(int id);
        Task<bool> Update(BankAccountUpdateDTO dto);

    }
}
