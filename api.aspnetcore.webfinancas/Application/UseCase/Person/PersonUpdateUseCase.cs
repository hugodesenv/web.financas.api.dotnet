namespace api.aspnetcore.webfinancas.Application.UseCase.Person
{
    using api.aspnetcore.webfinancas.Application.DTO.Person;
    using api.aspnetcore.webfinancas.Domain.Model;
    using api.aspnetcore.webfinancas.Infrastructure.Interface;

    public interface IUpdatePersonUseCase
    {
        Task<bool> Execute(PersonUpdateDTO dto);
    }

    public class UpdatePersonUseCase(IPersonRepository personRepository) : IUpdatePersonUseCase
    {
        public async Task<bool> Execute(PersonUpdateDTO dto)
        {
            Person? person = await personRepository.FindByID(dto.id) ?? throw new Exception("Person not found");

            person.name = dto.data.name;
            person.nickname = dto.data.nickname;
            person.active = dto.data.active;
            person.is_client = dto.type.client;
            person.is_employee = dto.type.employee;
            person.is_company = dto.type.company;

            return await personRepository.Update(person);
        }
    }
}
