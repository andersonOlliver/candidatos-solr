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
            var query = _queryFactory.BuildQuery(filtro);
            var x = query.ToString();
            return await _solrRepository.SearchAsync(query);
        }
    }
}
