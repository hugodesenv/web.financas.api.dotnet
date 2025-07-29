using api.aspnetcore.webfinancas.Application.DTO.BankAccount;
using api.aspnetcore.webfinancas.Application.UseCase.BankAccount;
using api.aspnetcore.webfinancas.Shared.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.aspnetcore.webfinancas.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class BankAccountController(
        IBankAccountFindAllUseCase findAllUseCase,
        IBankAccountInsertUseCase insertUseCase,
        IBankAccountFindByIDUseCase findByID,
        IBankAccountUpdateUseCase updateUseCase,
        IBankAccountDeleteUseCase deleteUseCase
    ) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var banks = await findAllUseCase.Execute();
            return Ok(CommomHelper.APIResponse(200, "Bank account list", banks));
        }

        [HttpPost]
        public async Task<IActionResult> Insert(BankAccountInsertDTO dto)
        {
            bool bsuccess = await insertUseCase.Execute(dto);

            return bsuccess
                ? Ok(CommomHelper.APIResponse(200, "Bank account inserted", null))
                : BadRequest(CommomHelper.APIResponse(400, "Fail to insert bank account", null));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindByID(int id)
        {
            BankAccountFindByIDDTO? bankAccount = await findByID.Execute(id);

            return bankAccount == null
                ? NotFound(CommomHelper.APIResponse(404, "Bank account not found", null))
                : Ok(CommomHelper.APIResponse(200, "Bank account by ID", bankAccount));
        }

        [HttpPut]
        public async Task<IActionResult> Update(BankAccountUpdateDTO dto)
        {
            var updated = await updateUseCase.Execute(dto);

            return updated
                ? Ok(CommomHelper.APIResponse(200, "Success", null))
                : NotFound(CommomHelper.APIResponse(404, "Occurs an error to update bank account", null));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool success = await deleteUseCase.Execute(id);

            return success
                ? Ok(CommomHelper.APIResponse(200, "Success", null))
                : NotFound(CommomHelper.APIResponse(404, "Bank account not found", null));
        }
    }
}
