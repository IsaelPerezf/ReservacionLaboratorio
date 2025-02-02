using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservacionLaboratorio.Models
{
    public class Usuarios
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)] // 🔹 Limita la longitud a 50 caracteres
        [Column(TypeName = "NVARCHAR(50)")] // 🔹 Define el tipo de datos en SQL Server
        public string Carnet { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Cedula { get; set; }

        [Required]
        public string TipoUsuario { get; set; } // Profesor, Estudiante, Empleado

        [Required]
        public string ContraseñaHash { get; set; }

        public bool Estado { get; set; }
    }
}
