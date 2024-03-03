using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace activos.Models
{
    public class Empleado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_empleado { get; set; }
        [Required, StringLength(50)]
        public string Nombre { get; set; }

        [Required, StringLength(13)]

        public string Cedula { get; set; }

        public int Id_departamento { get; set; }
        public Departamentos? Departamento { get; set; }

        public int Id_Tipo { get; set; }
        public Tipo? tipo { get; set; }

        public DateTime Fecha_Ingreso { get; set; }

        public bool Estado { get; set; }

    }
}
