using api.aspnetcore.webfinancas.Application.DTO.Purpose;
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
        IPurposeInsertUseCase insertUseCase, 
        IPurposeFindByIDUseCase findByIDUseCase,
        IPurposeUpdateUseCase updateUseCase,
        IPurposeDeleteByIDUseCase deleteByIDUseCase
     ) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var purposes = await findAllUseCase.Execute();
            return Ok(CommomHelper.APIResponse(200, "Purpose list", purposes));
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Purpose purpose)
        {
            bool saved = await insertUseCase.Execute(purpose);

            return saved
                ? Ok(CommomHelper.APIResponse(200, "Operation included", null))
                : BadRequest(CommomHelper.APIResponse(400, "Fail to insert purpose", null));
        }

        [HttpGet("id")]
        public async Task<IActionResult> FindByID([FromQuery] int id)
        {
            if(id <= 0)
            {
                return BadRequest(CommomHelper.APIResponse(400, "ID is required", null));
            }
            
            Purpose? purpose = await findByIDUseCase.Execute(id);

            return Ok(CommomHelper.APIResponse(200, "Purpose", purpose));
        }

        [HttpPut]
        public IActionResult Update([FromBody] PurposeUpdateDTO purpose)
        {
            bool success = updateUseCase.Execute(purpose);

            return success
                ? Ok(CommomHelper.APIResponse(200, "Purpose", purpose))
                : BadRequest(CommomHelper.APIResponse(400, "Fail to update purpose", null));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByID(int id)
        {
            bool success = await deleteByIDUseCase.Execute(id);

            return success
                ? Ok(CommomHelper.APIResponse(200, "Purpose deleted", null))
                : BadRequest(CommomHelper.APIResponse(400, "Fail to delete purpose", null));
        }
    }
}
