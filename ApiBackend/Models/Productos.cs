using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiBackend.Models
{
    public class Productos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Precio { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public int Stock { get; set; }
    }
}
