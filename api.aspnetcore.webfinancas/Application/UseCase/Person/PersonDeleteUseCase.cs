namespace api.aspnetcore.webfinancas.Application.UseCase.Person
{
    using api.aspnetcore.webfinancas.Domain.Model;
    using api.aspnetcore.webfinancas.Infrastructure.Interface;

    public interface IDeletePersonUseCase
    {
        Task<bool> Execute(int id);
    }

    public class DeletePersonUseCase(IPersonRepository repository) : IDeletePersonUseCase
    {
        public async Task<bool> Execute(int id)
        {
            Person? person = await repository.FindByID(id) ?? throw new Exception("Person not found");
            bool deleted = await repository.Delete(person);
            return deleted;
        }
    }
}
