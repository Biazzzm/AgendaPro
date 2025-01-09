using AgendaPro.Api.Models;
using AgendaPro.Api.Repositories;
using AgendaPro.Api.ViewModels;
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
        public async Task<IActionResult> PostAsync([FromBody] EditorViewModels model)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var contato = new Contact
            {

                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
            }
                ;

            await _contactRepository.CriarAsync(contato);

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

        [HttpPut("v1/contact/{Id}")]
        public async Task<IActionResult> PutAsync([FromRoute] int Id,[FromBody] EditorViewModels model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados do contato não podem ser nulos");
            }

            var contatoExistente = await _contactRepository.GetAsync(Id);

            if (contatoExistente == null)
            {
                return NotFound("Contato não encontrado");

            }

            contatoExistente.Name = string.IsNullOrEmpty(model.Name) ? contatoExistente.Name : model.Name;
            contatoExistente.Email = string.IsNullOrEmpty(model.Email) ? contatoExistente.Email : model.Email;
            contatoExistente.Phone = string.IsNullOrEmpty(model.Phone) ? contatoExistente.Phone : model.Phone;



            await _contactRepository.AlterarAsync(contatoExistente);

            return Ok();

        }

    }
}

