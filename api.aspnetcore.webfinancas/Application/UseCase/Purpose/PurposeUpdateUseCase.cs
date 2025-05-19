using api.aspnetcore.webfinancas.Infrastructure.Interface;

namespace api.aspnetcore.webfinancas.Application.UseCase.Purpose
{
    using api.aspnetcore.webfinancas.Application.DTO.Purpose;

    public interface IPurposeUpdateUseCase
    {
        bool Execute(PurposeUpdateDTO purpose);
    }

    public class PurposeUpdateUseCase(IPurposeRepository purposeRepository) : IPurposeUpdateUseCase
    {
        public bool Execute(PurposeUpdateDTO purpose)
        {
            return purposeRepository.Update(purpose);
        }
    }
}
