using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatitasEnCuidadoCleanArchitecture.Application.Interface;
using PatitasEnCuidadoCleanArchitecture.Domain.Entities;
using PatitasEnCuidadoCleanArchitecture.Infrastructure.Interface;

namespace PatitasEnCuidadoCleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoptanteController : ControllerBase
    {
        private readonly IAdoptanteService _adoptanteService;

        public AdoptanteController(IAdoptanteService adoptanteService)
        {
            _adoptanteService = adoptanteService;
        }

        // GET: api/adoptante
        [HttpGet]
        public async Task<IActionResult> GetAllAdoptantes()
        {
            var adoptantes = await _adoptanteService.GetAllAdoptanteAsync();
            return Ok(adoptantes);
        }

        // GET: api/adoptante/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdoptanteById(int id)
        {
            var adoptante = await _adoptanteService.GetAdoptanteByIdAsync(id);
            if (adoptante == null)
                return NotFound();

            return Ok(adoptante);
        }

        // POST: api/adoptante
        [HttpPost]
        public async Task<IActionResult> CreateAdoptante([FromBody] Adoptante adoptante, [FromForm] byte[] contenidoImagen = null)
        {
            if (adoptante == null)
                return BadRequest("La información del adoptante es inválida.");

            var createdAdoptante = await _adoptanteService.CreateAdoptanteAsync(adoptante, contenidoImagen);
            return CreatedAtAction(nameof(GetAdoptanteById), new { id = createdAdoptante.Id }, createdAdoptante);
        }

        // PUT: api/adoptante/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdoptante(int id, [FromBody] Adoptante adoptante, [FromForm] byte[] contenidoImagen = null)
        {
            if (adoptante == null || adoptante.Id != id)
                return BadRequest("La información del adoptante es inválida.");

            var existingAdoptante = await _adoptanteService.UpdateAdoptanteAsync(id, adoptante, contenidoImagen);
            if (existingAdoptante == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/adoptante/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdoptante(int id)
        {
            var deleted = await _adoptanteService.DeleteAdoptanteAsync(id);
            if (deleted == 0)
                return NotFound();

            return NoContent();
        }

    }
}
