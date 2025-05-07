namespace api.aspnetcore.webfinancas.Application.UseCase.Person
{
    using api.aspnetcore.webfinancas.Domain.Model;
    using api.aspnetcore.webfinancas.Infrastructure.Interface;

    public interface IInsertPersonUseCase
    {
        Task<bool> Execute(Person person);
    }

    public class InsertPersonUseCase(IPersonRepository repository) : IInsertPersonUseCase
    {
        public async Task<bool> Execute(Person person)
        {
            if (person == null)
            {
                return false;
            }

            int rowsAffected = await repository.Insert(person);
            return rowsAffected > 0;    
        }
    }
}
