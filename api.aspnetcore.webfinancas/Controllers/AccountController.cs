using api.aspnetcore.webfinancas.Application.DTO;
using api.aspnetcore.webfinancas.Application.UseCase.Account;
using api.aspnetcore.webfinancas.Shared.Helper;
using Microsoft.AspNetCore.Mvc;

namespace api.aspnetcore.webfinancas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController(IGenerateTokenUseCase generateTokenUseCase, IAuthenticationUseCase authenticationUseCase) : ControllerBase
    {
        [HttpPost("token")]
        public async Task<ActionResult> authentication([FromBody] AuthenticationDTO account)
        {
            bool isAuthenticated = await authenticationUseCase.execute(account);

            if (isAuthenticated == false)
            {
                return NotFound(CommomHelper.APIResponse(404, "User not found or inactive", null));
            }

            string token = generateTokenUseCase.execute();

            return Ok(CommomHelper.APIResponse(200, token, null));
        }
    }
}
