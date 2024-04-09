using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace activos.Models
{
    public class ActivoFijo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_activo_fijo { get; set; }

        [Required]
        [StringLength(100)]
        public string? Descripcion { get; set; }

        // Propiedad de navegación para el departamento
        [ForeignKey("Departamento")]
        public int Id_departamento { get; set; }
        public Departamento? Departamento { get; set; }

        // Propiedad de navegación para el tipo de activo
        [ForeignKey("TipoActivo")]
        public int Id_tipo_activo { get; set; }
        public TipoActivo? TipoActivo { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }

        [Required(ErrorMessage = "El campo Valor de compra es obligatorio.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El campo Depreciación acumulada solo puede contener números y un punto decimal opcional, con hasta 2 decimales.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El campo Valor de compra debe ser mayor que cero.")]
        [Column(TypeName = "decimal(18, 2)")]
        [DisplayFormat(DataFormatString = "{0:#,##0.00}")]
        public decimal ValorCompra { get; set; }

        [Required(ErrorMessage = "El campo Depreciación acumulada es obligatorio.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El campo Depreciación acumulada solo puede contener números y un punto decimal opcional, con hasta 2 decimales.")]
        [Range(0, double.MaxValue, ErrorMessage = "El campo Depreciación acumulada debe ser mayor o igual a cero.")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DepreciacionAcumulada { get; set; }

        public bool Estado { get; set; }
    }
}