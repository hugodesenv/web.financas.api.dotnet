using api.aspnetcore.webfinancas.Domain.Model;

namespace api.aspnetcore.webfinancas.Domain.Interface
{
    public interface IPersonRepository
    {
        Task<List<Person>> findAll();
        Task<Person?> findByID(int id);
        Task<int> insert(Person person);
    }
}
