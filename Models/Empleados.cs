namespace ReservacionLaboratorio.Models
{
    public class Empleados
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string TandaLaboral { get; set; } // Mañana, Tarde, Noche
        public DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }
    }
}
