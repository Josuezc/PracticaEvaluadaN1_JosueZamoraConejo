using System.ComponentModel.DataAnnotations;

namespace Practica1Jz.Models
{
    public class Restaurante
    {

       [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Dueno { get; set; }
        [Required]
        public string Provincia { get; set; }
        [Required]
        public string Canton { get; set; }
        [Required]
        public string Distrito { get; set; }
        [Required]
        public string DireccionExacta { get; set; }
         
    }
}
