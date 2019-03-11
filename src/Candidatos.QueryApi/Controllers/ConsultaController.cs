using AutoMapper;
using Candidatos.Domain.Entities;
using Candidatos.Domain.Services;
using Candidatos.QueryApi.Extensions;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        private readonly IMapper _mapper;
        private readonly ISchema _schema;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="consultaCandidatoService"></param>
        public ConsultaController(IConsultaCandidatoService consultaCandidatoService, IMapper mapper)
        {
            _consultaCandidatoService = consultaCandidatoService;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ConsultarAsync([FromQuery] Filtro filtro)
        {
            var resultado = await _consultaCandidatoService.ConsultaPaginadaAsync(filtro);
            var resultadoParse = _mapper.Map<IEnumerable<CandidatoDocumentoDto>>(resultado);
            Response.AddPagination(resultado.CurrentPage, resultado.PageSize, resultado.TotalCount, resultado.TotalPages);
            return Ok(resultadoParse);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            var inputs = query.Variables.ToInputs();
            var executionOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = query.Query,
                Inputs = inputs
            };

            return BadRequest("Não implementado");
        }
    }
}