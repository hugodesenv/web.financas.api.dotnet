using api.aspnetcore.webfinancas.Application.DTO.Purpose;

namespace api.aspnetcore.webfinancas.Infrastructure.Interface
{
    public interface IPurposeRepository
    {
        Task<List<PurposeFindAllDTO>> FindAll();
    }
}
