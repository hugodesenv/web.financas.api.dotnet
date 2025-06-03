using api.aspnetcore.webfinancas.Application.DTO.Person;
using api.aspnetcore.webfinancas.Application.UseCase.Person;
using api.aspnetcore.webfinancas.Domain.Model;
using api.aspnetcore.webfinancas.Shared.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.aspnetcore.webfinancas.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class PersonController(
        IFindAllPersonUseCase findAllPersonUse, 
        IFindPersonByIDUseCase findByIDUse, 
        IInsertPersonUseCase insertUse, 
        IDeletePersonUseCase deletePersonUse,
        IUpdatePersonUseCase updatePersonUse
    ) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> FindAll() {
            var people = await findAllPersonUse.Execute();
            return Ok(CommomHelper.APIResponse(200, "Person list", people));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindByID(int id)
        {
            Person? person = await findByIDUse.Execute(id);

            return person == null
                ? NotFound(CommomHelper.APIResponse(404, "Person not found", null))
                : Ok(CommomHelper.APIResponse(200, "Person by ID", person));
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Person person)
        {
            bool inserted = await insertUse.Execute(person);
            return inserted
                ? Ok(CommomHelper.APIResponse(200, "Operation concluded", null))
                : BadRequest(CommomHelper.APIResponse(400, "Fail to insert person", null));
        }

        [HttpPut]
        public async Task<IActionResult> Update(PersonUpdateDTO person)
        {
            try
            {
                bool updated = await updatePersonUse.Execute(person);

                return updated
                    ? Ok(CommomHelper.APIResponse(200, "Operation concluded", null))
                    : BadRequest(CommomHelper.APIResponse(400, "Occurs an error when updating the person", null));
            }
            catch (Exception e)
            {
                return BadRequest(CommomHelper.APIResponse(400, e.Message, null));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleted = await deletePersonUse.Execute(id);

            return deleted
                ? Ok(CommomHelper.APIResponse(200, "Operation concluded", null))
                : BadRequest(CommomHelper.APIResponse(400, "Occurs an error when deleting person", null));
        }
    }
}
