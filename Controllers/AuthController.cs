using Microsoft.AspNetCore.Mvc;
using Pagina_Administrador.Models;
using System.Linq;

namespace Pagina_Administrador.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Vista de inicio de sesión
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string clave)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Clave == clave);
            if (usuario != null)
            {
                // Guardamos los datos básicos en sesión
                HttpContext.Session.SetString("Usuario", usuario.NombreUsuario);
                HttpContext.Session.SetString("Rol", usuario.Rol);
                return RedirectToAction("Dashboard", "Home"); // Redirigir al panel general

            }

            ViewBag.Mensaje = "Credenciales incorrectas.";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
