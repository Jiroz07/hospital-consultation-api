using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsultaARSHospital.Models
{
    public class Doctores
    {
        public int IdDoctor { get; set; }

        [Required(ErrorMessage = "El nombre del doctor es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido del doctor es obligatorio.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El email del doctor es obligatorio.")]
        [EmailAddress(ErrorMessage = "Ingrese un email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El número de teléfono del doctor es obligatorio.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Ingrese un número de teléfono válido.")]
        public string Telefono { get; set; }

        public int IdHospital { get; set; }
        public Hospitales Hospital { get; set; }

    



    }
}
