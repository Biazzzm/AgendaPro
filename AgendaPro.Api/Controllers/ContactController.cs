using AgendaPro.Api.Models;
using AgendaPro.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AgendaPro.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class ContactController : ControllerBase
    {

        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }



        [HttpPost("v1/contact")]
        public async Task<IActionResult> PostAsync([FromBody] Contact model)
        {
            await _contactRepository.CriarAsync(model);

            return Ok(model);

        }

        [HttpGet("v1/contact")]
        public async Task<IActionResult> Get()
        {

            return Ok(await _contactRepository.ListarAsync());
        }

        [HttpGet("v1/contact/{Id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int Id)
        {

            return Ok(await _contactRepository.GetAsync(Id));
        }

        [HttpDelete("v1/contact/{Id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int Id)
        {
            await _contactRepository.DeletarAsync(Id);

            return Ok();

        }

        [HttpPut("v1/contact")]
        public async Task<IActionResult> PutAsync([FromBody] Contact model)
        {
            await _contactRepository.AlterarAsync(model);
            return Ok();

        }

    }
}

