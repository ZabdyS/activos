using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

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
        [CustomValidation(typeof(Utilidades), nameof(Utilidades.ValidaCedula))]
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

    public static class Utilidades
    {
        public static ValidationResult ValidaCedula(string pCedula)
        {
            if (!EsNumerico(pCedula))
            {
                return new ValidationResult("La cédula solo puede contener caracteres numéricos.", new[] { "Cedula" });
            }
            int vnTotal = 0;
            string vcCedula = pCedula.Replace("-", "");
            int pLongCed = vcCedula.Trim().Length;
            int[] digitoMult = new int[11] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1 };

            if (pLongCed != 11)
                return new ValidationResult("La cédula debe tener 11 caracteres.", new[] { "Cedula" });

            for (int vDig = 1; vDig <= pLongCed; vDig++)
            {
                int vCalculo = int.Parse(vcCedula.Substring(vDig - 1, 1)) * digitoMult[vDig - 1];
                if (vCalculo < 10)
                    vnTotal += vCalculo;
                else
                    vnTotal += int.Parse(vCalculo.ToString().Substring(0, 1)) + int.Parse(vCalculo.ToString().Substring(1, 1));
            }

            if (vnTotal % 10 == 0)
                return ValidationResult.Success;
            else
                return new ValidationResult("La cédula no es válida.", new[] { "Cedula" });

        }
        private static bool EsNumerico(string valor)
        {
            foreach (char c in valor)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
