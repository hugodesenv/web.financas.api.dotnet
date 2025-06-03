using api.aspnetcore.webfinancas.Shared.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.aspnetcore.webfinancas.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    [Authorize]
    public class EntryController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Insert()
        {
            return Ok("");
        }
    }
}
