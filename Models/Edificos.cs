namespace ReservacionLaboratorio.Models
{
    public class Edificios
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CampusId { get; set; }
        public Campus Campus { get; set; } // Relación con Campus
        public bool Estado { get; set; }
    }
}
