using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsultaARSHospital.Models
{
    public class Historico_paciente
    {
        public int IdHistoricoPaciente { get; set; }

        public int IdResultadoFactura { get; set; }

        public int IdEstatus { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime FechaCambioEstatus { get; set; }
    }
}