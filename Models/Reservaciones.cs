namespace ReservacionLaboratorio.Models
{
    public class Reservaciones
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public Empleados Empleado { get; set; } // Relación con Empleados
        public int AulaId { get; set; }
        public Aulas Aula { get; set; } // Relación con Aulas
        public int UsuarioId { get; set; }
        public Usuarios Usuario { get; set; } // Relación con Usuarios
        public DateTime FechaReservacion { get; set; }
        public int CantidadHoras { get; set; }
        public string Comentario { get; set; }
        public bool Estado { get; set; }
    }
}
