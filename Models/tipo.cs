using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace activos.Models
{
    public class Tipo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_tipo { get; set; }

        [Required]
        [StringLength(10)]
        public string? Tipo_persona { get; set; }

        // Propiedad de navegación inversa para empleados
       
    }
}
