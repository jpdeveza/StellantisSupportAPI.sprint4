using System.ComponentModel.DataAnnotations;

namespace StellantisSupportAPI.Models
{
    public class PesoDimensoes
    {
        [Key]
        public int Id { get; set; }
        public string Peso { get; set; }
        public string Comprimento { get; set; }
        public string Largura { get; set; }
        public string Altura { get; set; }
    }
}
