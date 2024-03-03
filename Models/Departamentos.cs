using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace activos.Models
{
    public class Departamentos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_departamento { get; set; }
        [Required, StringLength(50)]
        public string Departamento { get; set; }

        public bool Estado { get; set; }

        public ICollection<Empleado> empleado { get; set; }
    }
}
