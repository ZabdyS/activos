using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace activos.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [StringLength(100)]
        public string Correo { get; set; }
        [Required]
        [StringLength(100)]
        public string Clave { get; set; }

       

        
    }
}
