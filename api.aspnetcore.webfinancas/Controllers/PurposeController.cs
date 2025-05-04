using api.aspnetcore.webfinancas.Application.UseCase.Purpose;
using api.aspnetcore.webfinancas.Shared.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.aspnetcore.webfinancas.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class PurposeController(IPurposeFindAllUseCase findAllUseCase) : ControllerBase
    {
        [HttpGet("/find-all")]
        public async Task<IActionResult> FindAll()
        {
            var purposes = await findAllUseCase.Execute();
            return Ok(CommomHelper.APIResponse(200, "Purpose list", purposes));
        }
    }
}
