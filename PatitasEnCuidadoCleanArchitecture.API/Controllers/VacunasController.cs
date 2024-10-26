using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatitasEnCuidadoCleanArchitecture.Application.Interface;
using PatitasEnCuidadoCleanArchitecture.Domain.Entities;

namespace PatitasEnCuidadoCleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacunasController : ControllerBase
    {
        private readonly IVacunaService _vacunaService;

        public VacunasController(IVacunaService vacunaService)
        {
            _vacunaService = vacunaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetVacunasAll()
        {
            var vacunas = await _vacunaService.GetAllVacunasAsync();
            return Ok(vacunas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVacunasById(int id)
        {
            var vacuna = await _vacunaService.GetVacunasById(id);
            if (vacuna == null)
                return NotFound();

            return Ok(vacuna);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVacunas([FromBody] Vacuna vacuna)
        {
            if (vacuna == null)
                return BadRequest("La información de la vacuna es inválida.");

            var createdVacuna = await _vacunaService.CreateVacunaAsync(vacuna);
            return CreatedAtAction(nameof(GetVacunasById), new { id = createdVacuna.Id }, createdVacuna);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVacunas(int id, [FromBody] Vacuna vacuna)
        {
            if (vacuna == null || vacuna.Id != id)
                return BadRequest("La información de la vacuna es inválida.");

            var existingVacuna = await _vacunaService.UpdateVacunaAsync(id, vacuna);
            if (existingVacuna == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }

        // DELETE: api/vacunas/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVacunas(int id)
        {
            var existingVacuna = await _vacunaService.DeleteVacunaAsync(id);
            if (existingVacuna == 0)
                return NotFound();

            await _vacunaService.DeleteVacunaAsync(id);
            return NoContent();
        }
    }
}
