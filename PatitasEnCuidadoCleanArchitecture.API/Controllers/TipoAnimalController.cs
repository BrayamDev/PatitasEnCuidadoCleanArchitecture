using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatitasEnCuidadoCleanArchitecture.Application.Interface;
using PatitasEnCuidadoCleanArchitecture.Application.Services;
using PatitasEnCuidadoCleanArchitecture.Domain.Entities;

namespace PatitasEnCuidadoCleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoAnimalController : ControllerBase
    {

        private readonly ITipoAnimalService _tipoAnimalService;


        public TipoAnimalController(ITipoAnimalService tipoAnimalService)
        {
            _tipoAnimalService = tipoAnimalService;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetTipoAnimalesAll()
        {
            var tiposAnimal = await _tipoAnimalService.GetAllTipoAnimalAsync();
            return Ok(tiposAnimal);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipoAnimalById(int id)
        {
            var tipoAnimal = await _tipoAnimalService.GetTipoAnimalsById(id);
            if (tipoAnimal == null)
                return NotFound();

            return Ok(tipoAnimal);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTipoAnimal([FromBody] TipoAnimal tipoAnimal)
        {
            if (tipoAnimal == null)
                return BadRequest("La información del tipo de animal es inválida.");

            var createdTipoAnimal = await _tipoAnimalService.CreateTipoAnimalAsync(tipoAnimal);
            return CreatedAtAction(nameof(GetTipoAnimalById), new { id = createdTipoAnimal.Id }, createdTipoAnimal);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTipoAnimal(int id, [FromBody] TipoAnimal tipoAnimal)
        {
            if (tipoAnimal == null || tipoAnimal.Id != id)
                return BadRequest("La información del tipo de animal es inválida.");

            var existingTipoAnimal = await _tipoAnimalService.UpdateTipoAnimalAsync(id, tipoAnimal);
            if (existingTipoAnimal == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoAnimal(int id)
        {
            var existingTipoAnimal = await _tipoAnimalService.DeleteTipoAnimalAsync(id);
            if (existingTipoAnimal == 0)
                return NotFound();

            await _tipoAnimalService.DeleteTipoAnimalAsync(id);
            return NoContent();
        }



    }
}
