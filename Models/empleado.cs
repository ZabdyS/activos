using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace activos.Models
{
    public class Empleado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_empleado { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(20)]
        public string Cedula { get; set; }

        // Propiedad de navegación para el departamento
        [ForeignKey("Departamento")]
        public int Id_departamento { get; set; }
        public Departamento? Departamento { get; set; }

        // Propiedad de navegación para el tipo de persona
        [ForeignKey("Tipo")]
        public int Id_tipo { get; set; }
        public Tipo? Tipo { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }

        public bool Estado { get; set; }
    }
}
