using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultaARSHospital.Models
{
    public class Pacientes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Asegura que el ID se genere automáticamente
        public int IdPaciente { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria.")]
        public string Direccion { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "El email es obligatorio.")]
        public string Email { get; set; }

        public int IdSeguro { get; set; }
        public int IdHorario { get; set; }

        // Relaciones (asumiendo que existen y son necesarias)
        public virtual Seguros Seguro { get; set; }
        public virtual Horarios Horario { get; set; }
    }
}