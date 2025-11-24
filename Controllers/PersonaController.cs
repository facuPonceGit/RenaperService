//RenaperService/Controllers/PersonaController.cs
using Microsoft.AspNetCore.Mvc;
using RenaperService.Filters;
using RenaperService.Models;
using RenaperService.Services;

namespace RenaperService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(ApiKeyAuthFilter))] //API KEY
    public class PersonasController : ControllerBase
    {
        private readonly IRenaperService _renaperService;
        private readonly ILogger<PersonasController> _logger;

        public PersonasController(IRenaperService renaperService, ILogger<PersonasController> logger)
        {
            _renaperService = renaperService;
            _logger = logger;
        }

        [HttpGet("{dni}")]
        public async Task<IActionResult> ConsultarPersona(string dni, [FromQuery] string genero = "M")
        {
            try
            {
                _logger.LogInformation("Consultando persona con DNI: {Dni}", dni);

                if (string.IsNullOrWhiteSpace(dni) || dni.Length < 7)
                {
                    return BadRequest(new { error = "DNI inválido", message = "El DNI debe tener al menos 7 caracteres" });
                }

                var persona = await _renaperService.ConsultarPersonaAsync(dni, genero);

                if (persona == null)
                {
                    return NotFound(new
                    {
                        error = "Persona no encontrada",
                        message = "No se encontró ninguna persona con el DNI proporcionado"
                    });
                }

                return Ok(persona);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error consultando persona con DNI: {Dni}", dni);
                return StatusCode(500, new { error = "Error interno del servidor" });
            }
        }

        [HttpPost("consulta")]
        public async Task<IActionResult> ConsultaCompleta([FromBody] ConsultaPersonaRequest request)
        {
            try
            {
                _logger.LogInformation("Consulta completa para DNI: {Dni}", request.Dni);

                if (request == null || string.IsNullOrWhiteSpace(request.Dni))
                {
                    return BadRequest(new { error = "Solicitud inválida", message = "El DNI es requerido" });
                }

                var persona = await _renaperService.ConsultarPersonaAsync(request.Dni, request.Genero);

                if (persona == null)
                {
                    return NotFound(new
                    {
                        error = "Persona no encontrada",
                        message = "No se encontró ninguna persona con los datos proporcionados"
                    });
                }

                return Ok(new
                {
                    success = true,
                    data = persona,
                    consulta = new { timestamp = DateTime.UtcNow, operacion = "consulta_completa" }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en consulta completa para DNI: {Dni}", request.Dni);
                return StatusCode(500, new { error = "Error interno del servidor" });
            }
        }

        [HttpGet("health")]
        public IActionResult HealthCheck()
        {
            return Ok(new
            {
                status = "healthy",
                service = "RenaperService",
                version = "1.0.0",
                timestamp = DateTime.UtcNow
            });
        }
    }
}