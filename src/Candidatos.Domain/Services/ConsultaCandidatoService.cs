using Candidatos.Domain.Entities;
using Candidatos.Domain.Factory;
using Candidatos.Domain.Interfaces.Solr;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Candidatos.Domain.Services
{
    public class ConsultaCandidatoService : IConsultaCandidatoService
    {
        private readonly IQueryFactory _queryFactory;
        private readonly ISolrRepository _solrRepository;

        public ConsultaCandidatoService(IQueryFactory queryFactory, ISolrRepository solrRepository)
        {
            _queryFactory = queryFactory;
            _solrRepository = solrRepository;
        }

        public async Task<IEnumerable<CandidatoDocumento>> ConsultarAsync(Filtro filtro)
        {
            var query = _queryFactory.BuildParsedQuery(filtro);
            var start = (filtro.PageNumber - 1) * filtro.PageSize;
            var rows = filtro.PageSize;
            return await _solrRepository.SearchAsync(query, start, rows);
        }

        public async Task<PagedList<CandidatoDocumento>> ConsultaPaginadaAsync(Filtro filtro)
        {
            var query = _queryFactory.BuildParsedQuery(filtro);
            var start = (filtro.PageNumber - 1) * filtro.PageSize;
            var rows = filtro.PageSize;
            var resultado = await _solrRepository.SearchAsync(query, start, rows);

            var count = resultado.NumFound;
            
            return PagedList<CandidatoDocumento>.Create(resultado, filtro.PageNumber, filtro.PageSize, count);
        }
    }
}
