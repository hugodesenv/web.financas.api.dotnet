namespace api.aspnetcore.webfinancas.Application.UseCase.Person
{
    using api.aspnetcore.webfinancas.Application.DTO.Person;
    using api.aspnetcore.webfinancas.Domain.Model;
    using api.aspnetcore.webfinancas.Infrastructure.Interface;

    public interface IFindAllPersonUseCase
    {
        Task<List<Person>> Execute(PersonFindAllDTO filter);
    }

    public class FindAllPersonUseCase(IPersonRepository personRepository) : IFindAllPersonUseCase
    {
        public async Task<List<Person>> Execute(PersonFindAllDTO filter)
        {
            var people = await personRepository.FindAll(filter);
            return people;
        }
    }
}
