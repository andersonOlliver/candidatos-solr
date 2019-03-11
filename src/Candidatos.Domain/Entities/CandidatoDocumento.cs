using SolrNet.Attributes;
using System;

namespace Candidatos.Domain.Entities
{

    public class CandidatoDocumento : DocumentoBase
    {
        public CandidatoDocumento() : base() { }

        [SolrField(nameof(ANO_ELEICAO))]
        public string ANO_ELEICAO { get; set; }

        [SolrField(nameof(NR_TURNO))]
        public string NR_TURNO { get; set; }

        [SolrField(nameof(DS_ELEICAO))]
        public string DS_ELEICAO { get; set; }

        [SolrField(nameof(SG_UF))]
        public string SG_UF { get; set; }

        [SolrField(nameof(DS_CARGO))]
        public string DS_CARGO { get; set; }

        [SolrField(nameof(NR_CANDIDATO))]
        public string NR_CANDIDATO { get; set; }

        [SolrField(nameof(NM_CANDIDATO))]
        public string NM_CANDIDATO { get; set; }

        [SolrField(nameof(NM_EMAIL))]
        public string NM_EMAIL { get; set; }

        [SolrField(nameof(NR_PARTIDO))]
        public string NR_PARTIDO { get; set; }

        [SolrField(nameof(SG_PARTIDO))]
        public string SG_PARTIDO { get; set; }

        [SolrField(nameof(NM_PARTIDO))]
        public string NM_PARTIDO { get; set; }

        [SolrField(nameof(DS_NACIONALIDADE))]
        public string DS_NACIONALIDADE { get; set; }

        [SolrField(nameof(SG_UF_NASCIMENTO))]
        public string SG_UF_NASCIMENTO { get; set; }

        [SolrField(nameof(DS_COR_RACA))]
        public string DS_COR_RACA { get; set; }

        [SolrField(nameof(NM_COLIGACAO))]
        public string NM_COLIGACAO { get; set; }

        [SolrField(nameof(NM_MUNICIPIO_NASCIMENTO))]
        public string NM_MUNICIPIO_NASCIMENTO { get; set; }

        [SolrField(nameof(DS_GENERO))]
        public string DS_GENERO { get; set; }

        [SolrField(nameof(DS_GRAU_INSTRUCAO))]
        public string DS_GRAU_INSTRUCAO { get; set; }

        [SolrField(nameof(DS_ESTADO_CIVIL))]
        public string DS_ESTADO_CIVIL { get; set; }

        //[SolrField(nameof(DT_GERACAO))]
        //public string DT_GERACAO { get; set; }

        //[SolrField(nameof(HH_GERACAO))]
        //public DateTime HH_GERACAO { get; set; }


        //[SolrField(nameof(CD_TIPO_ELEICAO))]
        //public int CD_TIPO_ELEICAO { get; set; }

        //[SolrField(nameof(NM_TIPO_ELEICAO))]
        //public string NM_TIPO_ELEICAO { get; set; }

        //[SolrField(nameof(CD_ELEICAO))]
        //public int CD_ELEICAO { get; set; }

        //[SolrField(nameof(DT_ELEICAO))]
        //public string DT_ELEICAO { get; set; }

        //[SolrField(nameof(TP_ABRANGENCIA))]
        //public string TP_ABRANGENCIA { get; set; }

        //[SolrField(nameof(SG_UE))]
        //public string SG_UE { get; set; }

        //[SolrField(nameof(NM_UE))]
        //public string NM_UE { get; set; }

        //[SolrField(nameof(CD_CARGO))]
        //public int CD_CARGO { get; set; }

        //[SolrField(nameof(SQ_CANDIDATO))]
        //public long SQ_CANDIDATO { get; set; }

        //[SolrField(nameof(NM_URNA_CANDIDATO))]
        //public string NM_URNA_CANDIDATO { get; set; }

        //[SolrField(nameof(NM_SOCIAL_CANDIDATO))]
        //public string NM_SOCIAL_CANDIDATO { get; set; }

        //[SolrField(nameof(NR_CPF_CANDIDATO))]
        //public long NR_CPF_CANDIDATO { get; set; }

        //[SolrField(nameof(CD_SITUACAO_CANDIDATURA))]
        //public int CD_SITUACAO_CANDIDATURA { get; set; }

        //[SolrField(nameof(DS_SITUACAO_CANDIDATURA))]
        //public string DS_SITUACAO_CANDIDATURA { get; set; }

        //[SolrField(nameof(CD_DETALHE_SITUACAO_CAND))]
        //public int CD_DETALHE_SITUACAO_CAND { get; set; }

        //[SolrField(nameof(DS_DETALHE_SITUACAO_CAND))]
        //public string DS_DETALHE_SITUACAO_CAND { get; set; }

        //[SolrField(nameof(TP_AGREMIACAO))]
        //public string TP_AGREMIACAO { get; set; }

        //[SolrField(nameof(SQ_COLIGACAO))]
        //public long SQ_COLIGACAO { get; set; }

        //[SolrField(nameof(DS_COMPOSICAO_COLIGACAO))]
        //public string DS_COMPOSICAO_COLIGACAO { get; set; }

        //[SolrField(nameof(CD_NACIONALIDADE))]
        //public int CD_NACIONALIDADE { get; set; }

        //[SolrField(nameof(CD_MUNICIPIO_NASCIMENTO))]
        //public int CD_MUNICIPIO_NASCIMENTO { get; set; }

        //[SolrField(nameof(DT_NASCIMENTO))]
        //public string DT_NASCIMENTO { get; set; }

        //[SolrField(nameof(NR_IDADE_DATA_POSSE))]
        //public int NR_IDADE_DATA_POSSE { get; set; }

        //[SolrField(nameof(NR_TITULO_ELEITORAL_CANDIDATO))]
        //public long NR_TITULO_ELEITORAL_CANDIDATO { get; set; }

        //[SolrField(nameof(CD_GENERO))]
        //public int CD_GENERO { get; set; }

        //[SolrField(nameof(CD_GRAU_INSTRUCAO))]
        //public int CD_GRAU_INSTRUCAO { get; set; }

        //[SolrField(nameof(CD_ESTADO_CIVIL))]
        //public int CD_ESTADO_CIVIL { get; set; }

        //[SolrField(nameof(CD_COR_RACA))]
        //public int CD_COR_RACA { get; set; }

        //[SolrField(nameof(CD_OCUPACAO))]
        //public int CD_OCUPACAO { get; set; }

        //[SolrField(nameof(DS_OCUPACAO))]
        //public string DS_OCUPACAO { get; set; }

        //[SolrField(nameof(NR_DESPESA_MAX_CAMPANHA))]
        //public int NR_DESPESA_MAX_CAMPANHA { get; set; }

        //[SolrField(nameof(CD_SIT_TOT_TURNO))]
        //public int CD_SIT_TOT_TURNO { get; set; }

        //[SolrField(nameof(DS_SIT_TOT_TURNO))]
        //public string DS_SIT_TOT_TURNO { get; set; }

        //[SolrField(nameof(ST_REELEICAO))]
        //public string ST_REELEICAO { get; set; }

        //[SolrField(nameof(ST_DECLARAR_BENS))]
        //public string ST_DECLARAR_BENS { get; set; }

        //[SolrField(nameof(NR_PROTOCOLO_CANDIDATURA))]
        //public int NR_PROTOCOLO_CANDIDATURA { get; set; }

        //[SolrField(nameof(NR_PROCESSO))]
        //public string NR_PROCESSO { get; set; }

        public override string ToString()
        {
            return $"{SG_PARTIDO}: {NM_CANDIDATO}";
        }
    }
}
