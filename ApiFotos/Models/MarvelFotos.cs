using System.ComponentModel.DataAnnotations;

namespace ApiFotos.Models
{
    public class MarvelFotos
    {
        [Key]
        public  int Id { get; set; }
        [Required]
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        [Required]
        public string ImagenUrl { get; set; } = string.Empty;
    }
}
