namespace Candidatos.Domain.Entities
{
    public class Filtro : Paginated
    {

        public string NomeCandidato { get; set; }
        public string Partido { get; set; }
    }

    public class Paginated
    {
        private const int MaxPageSize = 50;
        private int pageSize = 10;

        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get => pageSize;
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }
    }
}
