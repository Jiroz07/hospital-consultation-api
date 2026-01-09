using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsultaARSHospital.Models
{
    public class Hospitales
    {
        public int IdHospital { get; set; }

        [Required(ErrorMessage = "El nombre del hospital es obligatorio.")]


        [Display(Name = "Nombre del Hospital")]
        public string NombreHospital { get; set; }

        [Required(ErrorMessage = "La dirección del hospital es obligatoria.")]


        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El número de teléfono del hospital es obligatorio.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Ingrese un número de teléfono válido.")]

        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
    }
}