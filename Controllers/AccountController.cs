using Microsoft.AspNetCore.Mvc;
using ReservacionLaboratorio.Data;
using ReservacionLaboratorio.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ReservacionLaboratorio.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Acción para mostrar la vista de login
        public IActionResult Login()
        {
            return View();
        }

        // Acción para procesar el login
        [HttpPost]
        public IActionResult Login(UsuarioLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Buscar el usuario por su carnet
                var usuario = _context.Usuarios.FirstOrDefault(u => u.Carnet == model.Carnet);

                if (usuario != null)
                {
                    // Verificar la contraseña
                    if (VerificarContraseña(model.Contraseña, usuario.ContraseñaHash))
                    {
                        // 🔹 Redirigir al usuario a la página de selección de campus
                        return RedirectToAction("Index", "Campus");
                    }
                    else
                    {
                        // Contraseña incorrecta
                        ModelState.AddModelError("", "La contraseña es incorrecta.");
                    }
                }
                else
                {
                    // Usuario no encontrado
                    ModelState.AddModelError("", "El usuario con el carnet ingresado no existe.");
                }
            }
            else
            {
                // Error de validación del modelo
                ModelState.AddModelError("", "Por favor, completa todos los campos correctamente.");
            }

            // Si hay errores, devolver la vista de login con los mensajes de error
            return View(model);
        }

        // Método para verificar la contraseña
        private bool VerificarContraseña(string contraseña, string hashAlmacenado)
        {
            using var sha256 = SHA256.Create();
            var hash = BitConverter.ToString(sha256.ComputeHash(Encoding.UTF8.GetBytes(contraseña))).Replace("-", "");
            return hash.Equals(hashAlmacenado, StringComparison.OrdinalIgnoreCase);
        }
    }
}
