using Microsoft.AspNetCore.Mvc;
using ReservacionLaboratorio.Data;
using ReservacionLaboratorio.Models;
using System.Linq;

namespace ReservacionLaboratorio.Controllers
{
    public class CampusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CampusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Acción para mostrar la lista de campus
        public IActionResult Index()
        {
            var campusList = _context.Campus.Where(c => c.Estado == true).ToList();
            Console.WriteLine($"Total de campus activos encontrados: {campusList.Count}");
            return View(campusList);
        }

        // Acción para mostrar los edificios relacionados con un campus
        public IActionResult SeleccionarEdificio(int campusId)
        {
            Console.WriteLine($"Campus seleccionado: {campusId}"); // Log de depuración

            var edificios = _context.Edificios
                .Where(e => e.CampusId == campusId && e.Estado == true)
                .ToList();

            Console.WriteLine($"Total de edificios encontrados: {edificios.Count}"); // Verificar si hay edificios

            var campus = _context.Campus.FirstOrDefault(c => c.Id == campusId);
            ViewData["CampusNombre"] = campus?.Nombre ?? "Campus Desconocido";

            return View(edificios);
        }

        // Acción para mostrar las aulas relacionadas con un edificio
        public IActionResult SeleccionarAula(int edificioId)
        {
            Console.WriteLine($"Edificio seleccionado: {edificioId}"); // Log de depuración

            var aulas = _context.Aulas
                .Where(a => a.EdificioId == edificioId && a.Estado == true)
                .ToList();

            Console.WriteLine($"Total de aulas encontradas: {aulas.Count}"); // Verificar si hay aulas

            if (!aulas.Any())
            {
                Console.WriteLine("No se encontraron aulas para este edificio.");
            }

            var edificio = _context.Edificios.FirstOrDefault(e => e.Id == edificioId);
            ViewData["EdificioNombre"] = edificio?.Nombre ?? "Edificio Desconocido";

            return View(aulas);
        }

        // Acción para mostrar los detalles del aula seleccionada antes de reservar
        public IActionResult Reservar(int aulaId)
        {
            Console.WriteLine($"Aula seleccionada para reservar: {aulaId}"); // Log de depuración

            var aula = _context.Aulas.FirstOrDefault(a => a.Id == aulaId);

            if (aula == null)
            {
                Console.WriteLine("No se encontró el aula.");
                return NotFound();
            }

            var edificio = _context.Edificios.FirstOrDefault(e => e.Id == aula.EdificioId);
            ViewData["EdificioNombre"] = edificio?.Nombre ?? "Edificio Desconocido";

            return View(aula);
        }
    }
}
