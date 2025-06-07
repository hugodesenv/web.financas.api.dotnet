using api.aspnetcore.webfinancas.Application.DTO.Entry;
using api.aspnetcore.webfinancas.Application.UseCase.Entry;
using api.aspnetcore.webfinancas.Shared.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.aspnetcore.webfinancas.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    [Authorize]
    public class EntryController(IEntryUseCase entryUseCase) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] EntryInsertDTO entry)
        {
            bool inserted = await entryUseCase.Execute(entry);
            
            return inserted
                ? Ok(CommomHelper.APIResponse(200, "Operation concluded", null))
                : BadRequest(CommomHelper.APIResponse(400, "Insert fail", null));
        }
    }
}
