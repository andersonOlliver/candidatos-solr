using Candidatos.Domain.Entities;
using Candidatos.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Candidatos.QueryApi.Controllers
{
    /// <summary>
    /// Consulta de Candidatos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaCandidatoService _consultaCandidatoService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="consultaCandidatoService"></param>
        public ConsultaController(IConsultaCandidatoService consultaCandidatoService)
        {
            _consultaCandidatoService = consultaCandidatoService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ConsultarAsync([FromQuery] Filtro filtro)
        {
            var resultado = await _consultaCandidatoService.ConsultarAsync(filtro);
            return Ok(resultado);
        }
    }
}