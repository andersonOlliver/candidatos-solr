using System.Diagnostics;

namespace Candidatos.Domain.Entities
{
    public class CandidatoDocumentoDto
    {
        public string Id { get; set; }
        public string AnoEleicao { get; set; }
        public string NrTurno { get; set; }
        public string DescricaoEleicao { get; set; }
        public string UF { get; set; }
        public string DescricaoCargo { get; set; }
        public string NumeroCandidato { get; set; }
        public string Numero_Candidato { get; set; }
        public string Email { get; set; }
        public string NumeroPartido { get; set; }
        public string SiglaPartido { get; set; }
        public string NomePartido { get; set; }
        public string Nacionalidade { get; set; }
        public string UfNascimento { get; set; }
        public string CorRaca { get; set; }
        public string Coligacao { get; set; }
        public string MunicipioNascimento { get; set; }
        public string Genero { get; set; }
        public string GrauIinstrucao { get; set; }
        public string EstadoCivil { get; set; }
    }
}
