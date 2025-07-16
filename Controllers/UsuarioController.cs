using Microsoft.AspNetCore.Mvc;
using Pagina_Administrador.Models;
using System.Linq;

namespace Pagina_Administrador.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Mostrar formulario (crear o editar) + lista de usuarios
        public IActionResult Index(int? id)
        {
            var usuario = id.HasValue ? _context.Usuarios.Find(id.Value) : new Usuario();

            var viewModel = new UsuarioViewModel
            {
                Usuario = usuario ?? new Usuario(),
                ListaUsuarios = _context.Usuarios.ToList()
            };

            return View(viewModel);
        }

        // Crear nuevo usuario
        [HttpPost]
        public IActionResult Crear(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            var viewModel = new UsuarioViewModel
            {
                Usuario = usuario,
                ListaUsuarios = _context.Usuarios.ToList()
            };

            return View("Index", viewModel);
        }

        // Editar usuario
        [HttpPost]
        public IActionResult Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Update(usuario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            var viewModel = new UsuarioViewModel
            {
                Usuario = usuario,
                ListaUsuarios = _context.Usuarios.ToList()
            };

            return View("Index", viewModel);
        }

        // Eliminar usuario
        public IActionResult Eliminar(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null) return NotFound();

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
