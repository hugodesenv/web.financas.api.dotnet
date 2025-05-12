using api.aspnetcore.webfinancas.Application.DTO.Person;
using api.aspnetcore.webfinancas.Infrastructure.Interface;

namespace api.aspnetcore.webfinancas.Application.UseCase.Person
{
    public interface IUpdatePersonUseCase
    {
        Task<bool> Execute(PersonUpdateDTO person);
    }

    public class UpdatePersonUseCase(IPersonRepository personRepository) : IUpdatePersonUseCase
    {
        public async Task<bool> Execute(PersonUpdateDTO person)
        {
            if (person == null || person.id <= 0)
            {
                throw new Exception("Person ID must be grather than zero.");    
            }

            return await personRepository.Update(person);
        }
    }
}
