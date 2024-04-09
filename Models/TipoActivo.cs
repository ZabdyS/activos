using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace activos.Models
{
    public class TipoActivo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_tipo_activo { get; set; }

        [Required]
        [StringLength(100)]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El campo Cuenta Contable Compra es requerido")]
        [StringLength(50)]
        public string? CuentaContableCompra { get; set; }

        [Required(ErrorMessage = "El campo Cuenta Contable Depreciacion es requerido")]
        [StringLength(50)]
        public string? CuentaContableDepreciacion { get; set; }

        public bool Estado { get; set; }

        // Propiedad de navegación para activos fijos
        public ICollection<ActivoFijo>? ActivosFijos { get; set; }
    }
}