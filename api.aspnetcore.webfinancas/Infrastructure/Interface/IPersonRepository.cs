using api.aspnetcore.webfinancas.Domain.Model;

namespace api.aspnetcore.webfinancas.Infrastructure.Interface
{
    public interface IPersonRepository
    {
        Task<List<Person>> FindAll();
        Task<Person?> FindByID(int id);
        Task<int> Insert(Person person);
    }
}
