using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace activos.Models
{
    public class tipo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_tipo { get; set; }
        [Required, StringLength(10)]
        public string tipo_persona { get; set; }

        public ICollection<empleado> empleado { get; set; }
    }
}
