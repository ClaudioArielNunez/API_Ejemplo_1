using System.ComponentModel.DataAnnotations;

namespace ApiFotos.Models
{
    public class MarvelFotos
    {
        [Key]
        public  int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        [Required]
        public string ImagenUrl { get; set;}
    }
}
