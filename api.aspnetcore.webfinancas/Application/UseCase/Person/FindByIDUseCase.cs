namespace api.aspnetcore.webfinancas.Application.UseCase.Person
{
    using api.aspnetcore.webfinancas.Domain.Model;
    using api.aspnetcore.webfinancas.Infrastructure.Interface;

    public interface IFindPersonByIDUseCase
    {
        Task<Person?> Execute(int id);
    }

    public class FindPersonByIDUseCase(IPersonRepository personRepository) : IFindPersonByIDUseCase
    {
        public async Task<Person?> Execute(int id)
        {
            Person? person = await personRepository.FindByID(id);
            return person;
        }
    }
}
