using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsultaARSHospital.Models
{
    public class Seguros
    {
        public int IdSeguro { get; set; }

        [Required(ErrorMessage = "El nombre del seguro es obligatorio.")]
        public string NombreSeguro { get; set; }

        public string TipoCobertura { get; set; }
    }
}