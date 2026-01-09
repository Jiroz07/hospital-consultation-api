using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsultaARSHospital.Models
{
    public class Especialidades
    {
        public int IdEspecialidad { get; set; }

        [Required(ErrorMessage = "El nombre de la especialidad es obligatorio.")]
        public string NombreEspecialidad { get; set; }

        public string Descripcion { get; set; }

        public int IdDoctor { get; set; }
        public Doctores Doctor { get; set; }
    }
}