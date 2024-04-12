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
        [AnioValido(ErrorMessage = "El año de proceso no es válido.")]
       
        public int AnioProceso { get; set; }

        [Required(ErrorMessage = "El mes de proceso es obligatorio.")]
        [MesValido(ErrorMessage = "El mes de proceso no es válido.")]
     
        public int MesProceso { get; set; }

        // Relación con el activo fijo
        [Required(ErrorMessage = "El activo fijo es obligatorio.")]
        [ForeignKey("ActivoFijo")]
        public int ActivoFijoId { get; set; }
        public ActivoFijo? ActivoFijo { get; set; }

        [Required(ErrorMessage = "La fecha de proceso es obligatoria.")]
        [DataType(DataType.Date)]
        public DateTime FechaProceso { get; set; }

        [Required(ErrorMessage = "El monto depreciado es obligatorio.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El campo Depreciación acumulada solo puede contener números y un punto decimal opcional, con hasta 2 decimales.")]
        [Range(0, double.MaxValue, ErrorMessage = "El monto depreciado debe ser mayor o igual a cero.")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal MontoDepreciado { get; set; }

        [Required(ErrorMessage = "El campo Depreciación acumulada es obligatorio.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El campo Depreciación acumulada solo puede contener números y un punto decimal opcional, con hasta 2 decimales.")]
        [Range(0, double.MaxValue, ErrorMessage = "El campo Depreciación acumulada debe ser mayor o igual a cero.")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DepreciacionAcumulada { get; set; }

        [Required(ErrorMessage = "La cuenta de compra es obligatoria.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El campo Cuenta de Compra solo puede contener números y un punto decimal opcional, con hasta 2 decimales.")]
        [Range(0, double.MaxValue, ErrorMessage = "El campo Cuenta de Compradebe ser mayor o igual a cero.")]
        [StringLength(50)]
        public string? CuentaCompra { get; set; }

        [Required(ErrorMessage = "La cuenta de depreciación es obligatoria.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El campo Cuenta de Depreciación solo puede contener números y un punto decimal opcional, con hasta 2 decimales.")]
        [Range(0, double.MaxValue, ErrorMessage = "El campo Cuenta de Depreciación debe ser mayor o igual a cero.")]
        [StringLength(50)]
        public string? CuentaDepreciacion { get; set; }
    }

    public class AnioValidoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is int anio)
            {
                int anioMinimo = 1900; // Ajusta este valor según tus requisitos para los años anteriores
                int anioMaximo = DateTime.Now.Year + 100; // Ajusta este valor según tus requisitos para los años futuros

                if (anio >= anioMinimo && anio <= anioMaximo)
                {
                    return ValidationResult.Success; // El año es válido
                }
            }

            return new ValidationResult(ErrorMessage ?? "El año no es válido.");
        }
    }

    public class MesValidoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is int mes)
            {
                if (mes >= 1 && mes <= 12)
                {
                    return ValidationResult.Success; // El mes es válido
                }
            }

            return new ValidationResult(ErrorMessage ?? "El mes no es válido.");
        }
    }
}

