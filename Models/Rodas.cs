using System.ComponentModel.DataAnnotations;

namespace StellantisSupportAPI.Models
{
    public class Rodas
    {
        [Key]
        public int Id { get; set; }
        public string Tamanho { get; set; }
        public string Material { get; set; }
    }
}
