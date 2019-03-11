using AutoMapper;
using Candidatos.Domain.Entities;

namespace Candidatos.QueryApi.Profiles
{
    public class CandidatoDocumentoProfile: Profile
    {
        public CandidatoDocumentoProfile()
        {
            CreateMap<CandidatoDocumento, CandidatoDocumentoDto>()
                .ConstructUsing(s => new CandidatoDocumentoDto
                {
                    AnoEleicao = s.ANO_ELEICAO,
                    NrTurno = s.NR_TURNO,
                    DescricaoEleicao = s.DS_ELEICAO,
                    UF = s.SG_UF,
                    DescricaoCargo = s.DS_CARGO,
                    NumeroCandidato = s.NR_CANDIDATO,
                    Email = s.NM_EMAIL,
                    NumeroPartido = s.NR_PARTIDO,
                    SiglaPartido = s.SG_PARTIDO,
                    Nacionalidade = s.DS_NACIONALIDADE,
                    UfNascimento = s.SG_UF_NASCIMENTO,
                    CorRaca = s.DS_COR_RACA,
                    Coligacao = s.NM_COLIGACAO,
                    MunicipioNascimento = s.NM_MUNICIPIO_NASCIMENTO,
                    Genero = s.DS_GENERO,
                    GrauIinstrucao = s.DS_GRAU_INSTRUCAO,
                    EstadoCivil = s.DS_ESTADO_CIVIL
                });
        }
    }
}
