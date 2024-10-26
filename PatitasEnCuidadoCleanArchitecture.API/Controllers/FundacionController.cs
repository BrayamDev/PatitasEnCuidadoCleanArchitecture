using Microsoft.AspNetCore.Mvc;
using PatitasEnCuidadoCleanArchitecture.Application.Interface;
using PatitasEnCuidadoCleanArchitecture.Domain.Entities;

namespace PatitasEnCuidadoCleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundacionController : ControllerBase
    {
        private readonly IFundacionService _fundacionService;

        public FundacionController(IFundacionService fundacionService)
        {
            _fundacionService = fundacionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFundacionAll()
        {
            var fundacion = await _fundacionService.GetAllFundacionAsync();
            return Ok(fundacion);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFundacionById(int id)
        {
            var fundacion = await _fundacionService.GetFundacionByIdAsync(id);
            if (fundacion == null)
                return NotFound();

            return Ok(fundacion);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFundacion([FromBody] Fundacion fundacion)
        {
            if (fundacion == null)
                return BadRequest("La información de la vacuna es inválida.");

            var fundacionVacuna = await _fundacionService.CreateFundacionAsync(fundacion);
            return CreatedAtAction(nameof(GetFundacionById), new { id = fundacionVacuna.Id }, fundacionVacuna);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFundacion(int id, [FromBody] Fundacion fundacion)
        {
            if (fundacion == null || fundacion.Id != id)
                return BadRequest("La información de la fundacion es inválida.");

            var existingFundacion = await _fundacionService.UpdateFundacionAsync(id, fundacion);
            if (existingFundacion == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }

        // DELETE: api/vacunas/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFundacion(int id)
        {
            var existingFundacion = await _fundacionService.DeleteFundacionAsync(id);
            if (existingFundacion == 0)
                return NotFound();

            await _fundacionService.DeleteFundacionAsync(id);
            return NoContent();
        }
    }
}
