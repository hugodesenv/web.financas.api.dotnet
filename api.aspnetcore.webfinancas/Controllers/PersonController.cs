using api.aspnetcore.webfinancas.Domain.Interface;
using api.aspnetcore.webfinancas.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.aspnetcore.webfinancas.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository) => this._personRepository = personRepository;

        [HttpGet]
        public async Task<IActionResult> findAll() {
            var list = await _personRepository.findAll();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> findByID(int id)
        {
            if (id <= 0) {
                return BadRequest("Field ID must be grather than zero.");
            }

            Person? person = await _personRepository.findByID(id);

            if (person == null)
            {
                return NotFound("Person not found!");
            }

            return Ok(person);
        }

        [HttpPost]
        public async Task<IActionResult> include(Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }

            var newID = await _personRepository.insert(person);

            if (newID <= 0)
            {
                return BadRequest("Operation aborted!");
            }

            return Ok("Operation concluded!");
        }

        [HttpPut]
        public async Task<IActionResult> update(Person person)
        {
            return Ok();
        }
    }
}
