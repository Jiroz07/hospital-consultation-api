using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsultaARSHospital.Models
{
    public class Horarios
    {
        public int IdHorario { get; set; }

        public int IdDoctor { get; set; }

        [Required(ErrorMessage = "El día de la semana es obligatorio.")]
        public string DiaSemana { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan HoraInicio { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan HoraFin { get; set; }
    }
}