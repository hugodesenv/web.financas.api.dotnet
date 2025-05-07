namespace api.aspnetcore.webfinancas.Application.UseCase.Person
{
    using api.aspnetcore.webfinancas.Domain.Model;
    using api.aspnetcore.webfinancas.Infrastructure.Interface;

    public interface IFindAllPersonUseCase
    {
        Task<List<Person>> Execute();
    }

    public class FindAllPersonUseCase(IPersonRepository personRepository) : IFindAllPersonUseCase
    {
        public async Task<List<Person>> Execute()
        {
            var people = await personRepository.FindAll();
            return people;
        }
    }
}
