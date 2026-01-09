using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsultaARSHospital.Models
{
    public class Estatus
    {

        public int IdEstatus { get; set; }

        [Required(ErrorMessage = "El nombre del estatus es obligatorio.")]
        public string NombreEstatus { get; set; }

        public string Descripcion { get; set; }
    }
}