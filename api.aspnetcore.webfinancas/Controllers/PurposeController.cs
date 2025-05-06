using api.aspnetcore.webfinancas.Application.UseCase.Purpose;
using api.aspnetcore.webfinancas.Domain.Model;
using api.aspnetcore.webfinancas.Shared.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.aspnetcore.webfinancas.Controllers
{
    [ApiController]
    [Authorize] 
    [Route("api/[controller]")]
    public class PurposeController(
        IPurposeFindAllUseCase findAllUseCase, 
        IPurposeFindByIDUseCase findByID, 
        IPurposeInsertUseCase insertUseCase
    ) : ControllerBase
    {
        [HttpGet("find-all")]
        public async Task<IActionResult> FindAll()
        {
            var purposes = await findAllUseCase.Execute();
            return Ok(CommomHelper.APIResponse(200, "Purpose list", purposes));
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromQuery] Purpose purpose)
        {
            var purposeQuery = await findByID.Execute(purpose.id);

            if (purposeQuery == null)
            {
                return NotFound("Purpose not found");
            }

            bool saved = await insertUseCase.Execute(purpose);

            return saved
                ? Ok(CommomHelper.APIResponse(200, "Operation included", null))
                : BadRequest(CommomHelper.APIResponse(400, "Fail to insert purpose", null));
        }
    }
}
