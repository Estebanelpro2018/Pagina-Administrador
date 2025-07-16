using Microsoft.AspNetCore.Mvc;
using Pagina_Administrador.Models;
using System.Linq;

namespace Pagina_Administrador.Controllers
{
    public class CarritoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarritoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Mostrar todos + formulario (crear o editar)
        public IActionResult Index(int? id)
        {
            var carrito = id.HasValue ? _context.Carrito.Find(id.Value) : new Carrito();

            var viewModel = new CarritoViewModel
            {
                Carrito = carrito ?? new Carrito(),
                ListaCarrito = _context.Carrito.ToList()
            };

            return View(viewModel);
        }

        // Crear nuevo registro
        [HttpPost]
        public IActionResult Crear(Carrito carrito)
        {
            if (ModelState.IsValid)
            {
                _context.Carrito.Add(carrito);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            var viewModel = new CarritoViewModel
            {
                Carrito = carrito,
                ListaCarrito = _context.Carrito.ToList()
            };

            return View("Index", viewModel);
        }

        // Editar existente
        [HttpPost]
        public IActionResult Editar(Carrito carrito)
        {
            if (ModelState.IsValid)
            {
                _context.Carrito.Update(carrito);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            var viewModel = new CarritoViewModel
            {
                Carrito = carrito,
                ListaCarrito = _context.Carrito.ToList()
            };

            return View("Index", viewModel);
        }

        // Eliminar
        public IActionResult Eliminar(int id)
        {
            var carrito = _context.Carrito.Find(id);
            if (carrito == null) return NotFound();

            _context.Carrito.Remove(carrito);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
