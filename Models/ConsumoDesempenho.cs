using System.ComponentModel.DataAnnotations;

namespace StellantisSupportAPI.Models
{
    public class ConsumoDesempenho
    {
        [Key]
        public int Id { get; set; }
        public string ConsumoUrbano { get; set; }
        public string ConsumoRodoviario { get; set; }
        public string Aceleracao { get; set; }
        public string VelocidadeMaxima { get; set; }
    }
}

