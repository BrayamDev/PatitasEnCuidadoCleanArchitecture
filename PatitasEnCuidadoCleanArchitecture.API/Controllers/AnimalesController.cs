using Microsoft.AspNetCore.Mvc;
using PatitasEnCuidadoCleanArchitecture.Application.Interface;
using PatitasEnCuidadoCleanArchitecture.Domain.Entities;
using PatitasEnCuidadoCleanArchitecture.Infrastructure.Interface;

namespace PatitasEnCuidadoCleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalesController : ControllerBase
    {
        private readonly IAnimalRepository _animalService;

        public AnimalesController(IAnimalRepository animalService)
        {
            _animalService = animalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAnimales()
        {
            var animales = await _animalService.GetAllAnimalAsync();
            return Ok(animales);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimalById(int id)
        {
            var animal = await _animalService.GetAnimalByIdAsync(id);
            if (animal == null)
                return NotFound();

            return Ok(animal);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnimal([FromForm] Animal animal, [FromForm] IFormFile imagen)
        {
            if (animal == null)
                return BadRequest("La información del animal es inválida.");

            byte[] contenidoImagen = null;

            // Procesar la imagen si se proporciona
            if (imagen != null && imagen.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await imagen.CopyToAsync(memoryStream);
                    contenidoImagen = memoryStream.ToArray();
                }
            }

            var createdAnimal = await _animalService.CreateAnimalAsync(animal, contenidoImagen);
            return CreatedAtAction(nameof(GetAnimalById), new { id = createdAnimal.Id }, createdAnimal);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnimal(int id, [FromForm] Animal animal, [FromForm] IFormFile imagen)
        {
            if (animal == null || animal.Id != id)
                return BadRequest("La información del animal es inválida.");

            byte[] contenidoImagen = null;

            // Procesar la imagen si se proporciona
            if (imagen != null && imagen.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await imagen.CopyToAsync(memoryStream);
                    contenidoImagen = memoryStream.ToArray();
                }
            }

            var existingAnimal = await _animalService.UpdateAnimalAsync(id, animal, contenidoImagen);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            var existingAnimal = await _animalService.DeleteAnimalAsync(id);
            if (existingAnimal == 0)
                return NotFound();

            return NoContent();
        }
    }
}
