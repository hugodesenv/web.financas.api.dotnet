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
    public class PurposeController : ControllerBase
    {
        private readonly IPurposeFindAllUseCase _findAllUseCase;
        private readonly IPurposeFindByID _findByID;

        public PurposeController(IPurposeFindAllUseCase findAllUseCase, IPurposeFindByID findByID)
        {
            _findAllUseCase = findAllUseCase;
            _findByID = findByID;
        }

        [HttpGet("find-all")]
        public async Task<IActionResult> FindAll()
        {
            var purposes = await _findAllUseCase.Execute();
            return Ok(CommomHelper.APIResponse(200, "Purpose list", purposes));
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromQuery] Purpose purpose)
        {
            var purposeQuery = await this._findByID.Execute(purpose.id);

            if (purposeQuery == null)
            {
                return NotFound("Purpose not found");
            }

            //==> chamar funcao para gravar aqui.

            return Ok(CommomHelper.APIResponse(200, "Operation included", null));
        }
    }
}
