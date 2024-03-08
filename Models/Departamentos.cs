using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace activos.Models
{
    public class Departamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_departamento { get; set; }

        [Required]
        [StringLength(50)]
        public string? Descripcion { get; set; }

        public bool Estado { get; set; }
    }
}

