using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace activos.Models
{
    public class CalculoDepreciacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El año de proceso es obligatorio.")]
        public int AnioProceso { get; set; }

        [Required(ErrorMessage = "El mes de proceso es obligatorio.")]
        public int MesProceso { get; set; }

        // Relación con el activo fijo
        [Required(ErrorMessage = "El activo fijo es obligatorio.")]
        [ForeignKey("ActivoFijo")]
        public int ActivoFijoId { get; set; }
        public ActivoFijo ActivoFijo { get; set; }

        [Required(ErrorMessage = "La fecha de proceso es obligatoria.")]
        [DataType(DataType.Date)]
        public DateTime FechaProceso { get; set; }

        [Required(ErrorMessage = "El monto depreciado es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El monto depreciado debe ser mayor o igual a cero.")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal MontoDepreciado { get; set; }

        [Required(ErrorMessage = "La depreciación acumulada es obligatoria.")]
        [Range(0, double.MaxValue, ErrorMessage = "La depreciación acumulada debe ser mayor o igual a cero.")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DepreciacionAcumulada { get; set; }

        [Required(ErrorMessage = "La cuenta de compra es obligatoria.")]
        [StringLength(50)]
        public string CuentaCompra { get; set; }

        [Required(ErrorMessage = "La cuenta de depreciación es obligatoria.")]
        [StringLength(50)]
        public string CuentaDepreciacion { get; set; }
    }
}

