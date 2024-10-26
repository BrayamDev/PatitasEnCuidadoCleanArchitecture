using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatitasEnCuidadoCleanArchitecture.Application.Interface;
using PatitasEnCuidadoCleanArchitecture.Domain.Entities;
using PatitasEnCuidadoCleanArchitecture.Infrastructure.Interface;

namespace PatitasEnCuidadoCleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalAdoptanteController : ControllerBase
    {
        private readonly IAnimalAdoptanteRepository _animalAdoptanteService;

        public AnimalAdoptanteController(IAnimalAdoptanteRepository animalAdoptanteService)
        {
            _animalAdoptanteService = animalAdoptanteService;
        }

        // GET: api/AnimalAdoptante
        [HttpGet]
        public async Task<IActionResult> GetAllAnimalAdoptantes()
        {
            var animalAdoptantes = await _animalAdoptanteService.GetAllAnimalAdoptanteAsync();
            return Ok(animalAdoptantes);
        }

        // GET: api/AnimalAdoptante/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimalAdoptanteById(int id)
        {
            var animalAdoptante = await _animalAdoptanteService.GetAnimalAdoptanteByIdAsync(id);
            if (animalAdoptante == null)
                return NotFound();

            return Ok(animalAdoptante);
        }

        // POST: api/AnimalAdoptante
        [HttpPost]
        public async Task<IActionResult> CreateAnimalAdoptante([FromBody] AnimalAdoptante animalAdoptante)
        {
            if (animalAdoptante == null)
                return BadRequest("La información del animal adoptante es inválida.");

            var createdAnimalAdoptante = await _animalAdoptanteService.CreateAnimalAdoptanteAsync(animalAdoptante);
            return CreatedAtAction(nameof(GetAnimalAdoptanteById), new { id = createdAnimalAdoptante.Id }, createdAnimalAdoptante);
        }

        // PUT: api/AnimalAdoptante/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnimalAdoptante(int id, [FromBody] AnimalAdoptante animalAdoptante)
        {
            if (animalAdoptante == null || animalAdoptante.Id != id)
                return BadRequest("La información del animal adoptante es inválida.");

            var updated = await _animalAdoptanteService.UpdateAnimalAdoptanteAsync(id, animalAdoptante);
            if (updated == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/AnimalAdoptante/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimalAdoptante(int id)
        {
            var deleted = await _animalAdoptanteService.DeleteAnimalAdoptanteAsync(id);
            if (deleted == 0)
                return NotFound();

            return NoContent();
        }



    }
}
