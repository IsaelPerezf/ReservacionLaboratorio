namespace ReservacionLaboratorio.Models
{
    public class Aulas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int TipoAulaId { get; set; }
        public TiposAulas TipoAula { get; set; } // Relación con TiposAulas
        public int EdificioId { get; set; }
        public Edificios Edificio { get; set; } // Relación con Edificios
        public int Capacidad { get; set; }
        public int CuposReservados { get; set; }
        public bool Estado { get; set; }
    }
}
