using api.aspnetcore.webfinancas.Application.DTO.Entry;
using api.aspnetcore.webfinancas.Application.UseCase.Entry;
using api.aspnetcore.webfinancas.Shared.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.aspnetcore.webfinancas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EntryController(
        IEntryUseCase entryUseCase,
        IEntryFindAllUseCase findAllUseCase,
        IEntryDeleteUseCase deleteUseCase
    ) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] EntryInsertDTO entry)
        {
            bool inserted = await entryUseCase.Execute(entry);
            
            return inserted
                ? Ok(CommomHelper.APIResponse(200, "Operation concluded", null))
                : BadRequest(CommomHelper.APIResponse(400, "Insert fail", null));
        }

        [HttpGet]
        public async Task<IActionResult> FindAll([FromQuery] EntryFindAllRequestDTO request)
        {
            var entries = await findAllUseCase.Execute(request);
            return Ok(CommomHelper.APIResponse(200, "List of entries", entries));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Console.WriteLine(id);
            bool deleted = await deleteUseCase.Execute(id);

            return deleted 
                ? Ok(CommomHelper.APIResponse(200, "Operation concluded", null))
                : BadRequest(CommomHelper.APIResponse(404, "Entry not found", null));
        }
    }
}
