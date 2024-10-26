using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatitasEnCuidadoCleanArchitecture.Application.Interface;
using PatitasEnCuidadoCleanArchitecture.Application.Services;
using PatitasEnCuidadoCleanArchitecture.Domain.Entities;
using PatitasEnCuidadoCleanArchitecture.Infrastructure.Interface;

namespace PatitasEnCuidadoCleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalFundacionController : ControllerBase
    {
        private readonly IAnimalFundacionRepository _animalFundacionService;

        public AnimalFundacionController(IAnimalFundacionRepository animalFundacionService)
        {
            _animalFundacionService = animalFundacionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAnimalFundaciones()
        {
            var animalFundaciones = await _animalFundacionService.GetAllAnimalFundacionAsync();
            return Ok(animalFundaciones);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimalFundacionById(int id)
        {
            var animalFundacion = await _animalFundacionService.GetAnimalFundacionByIdAsync(id);
            if (animalFundacion == null)
                return NotFound();

            return Ok(animalFundacion);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnimalFundacion([FromBody] AnimalFundacion animalFundacion)
        {
            if (animalFundacion == null)
                return BadRequest("La información de la relación entre animal y fundación es inválida.");

            var createdAnimalFundacion = await _animalFundacionService.CreateAnimalFundacionAsync(animalFundacion);
            return CreatedAtAction(nameof(GetAnimalFundacionById), new { id = createdAnimalFundacion.Id }, createdAnimalFundacion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnimalFundacion(int id, [FromBody] AnimalFundacion animalFundacion)
        {
            if (animalFundacion == null || animalFundacion.Id != id)
                return BadRequest("La información de la relación entre animal y fundación es inválida.");

            var existingAnimalFundacion = await _animalFundacionService.UpdateAnimalFundacionAsync(id, animalFundacion);
            if (existingAnimalFundacion == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimalFundacion(int id)
        {
            var existingAnimalFundacion = await _animalFundacionService.DeleteAnimalFundacionAsync(id);
            if (existingAnimalFundacion == 0)
                return NotFound();

            await _animalFundacionService.DeleteAnimalFundacionAsync(id);
            return NoContent();
        }


    }
}
