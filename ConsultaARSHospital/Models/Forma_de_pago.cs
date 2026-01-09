using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsultaARSHospital.Models
{
    public class Forma_de_pago
    {
        public int IdFormaPago { get; set; }

        [Required(ErrorMessage = "El nombre de la forma de pago es obligatorio.")]
        public string NombreFormaPago { get; set; }
    }
}