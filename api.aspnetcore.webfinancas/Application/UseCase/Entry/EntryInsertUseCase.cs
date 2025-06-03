namespace api.aspnetcore.webfinancas.Application.UseCase.Entry
{
    public interface IEntryUseCase
    {
        Task<bool> Execute();
    }

    public class EntryInsertUseCase : IEntryUseCase
    {
        public Task<bool> Execute()
        {
            throw new NotImplementedException();
        }
    }
}
