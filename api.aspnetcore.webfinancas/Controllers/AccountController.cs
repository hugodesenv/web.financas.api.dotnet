using api.aspnetcore.webfinancas.Application.DTO;
using api.aspnetcore.webfinancas.Application.UseCase.Account;
using api.aspnetcore.webfinancas.Application.Utils;
using api.aspnetcore.webfinancas.Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace api.aspnetcore.webfinancas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController(IAccountRepository accountRepository) : ControllerBase
    {
        [HttpPost("token")]
        public async Task<ActionResult> authentication([FromBody] AuthenticationDTO account)
        {
            AuthenticationUseCase authenticationCase = new(accountRepository);
            bool isAuthenticated = await authenticationCase.execute(account);

            if (isAuthenticated == false)
            {
                return NotFound(HandleUtils.APIResponse(404, "User not found or inactive", null));
            }

            GenerateTokenUseCase generateTokenUseCase = new();
            string token = generateTokenUseCase.execute();

            Console.Write(token);

            return Ok(HandleUtils.APIResponse(200, token, null));
        }
    }
}
