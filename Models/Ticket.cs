namespace StellantisSupportAPI.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string ClienteNome { get; set; }
        public string DescricaoProblema { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Status { get; set; }
    }
}
