using api.aspnetcore.webfinancas.Application.DTO.Person;
using api.aspnetcore.webfinancas.Domain.Model;

namespace api.aspnetcore.webfinancas.Infrastructure.Interface
{
    public interface IPersonRepository
    {
        Task<List<Person>> FindAll(PersonFindAllDTO filter);
        Task<Person?> FindByID(int id);
        Task<int> Insert(Person person);
        Task<bool> Delete(Person person);
        Task<bool> Update(Person person);
    }
}
