using Microsoft.AspNetCore.Mvc;
using Pagina_Administrador.Models;
using System.Linq;

namespace Pagina_Administrador.Controllers
{
    public class InventarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InventarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Mostrar formulario + lista
        public IActionResult Index(int? id)
        {
            var inventario = id.HasValue ? _context.Inventario.Find(id.Value) : new Inventario();

            var viewModel = new InventarioViewModel
            {
                Inventario = inventario ?? new Inventario(),
                ListaInventario = _context.Inventario.ToList()
            };

            return View(viewModel);
        }

        // Crear
        [HttpPost]
        public IActionResult Crear(Inventario inventario)
        {
            if (ModelState.IsValid)
            {
                _context.Inventario.Add(inventario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            var viewModel = new InventarioViewModel
            {
                Inventario = inventario,
                ListaInventario = _context.Inventario.ToList()
            };

            return View("Index", viewModel);
        }

        // Editar
        [HttpPost]
        public IActionResult Editar(Inventario inventario)
        {
            if (ModelState.IsValid)
            {
                _context.Inventario.Update(inventario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            var viewModel = new InventarioViewModel
            {
                Inventario = inventario,
                ListaInventario = _context.Inventario.ToList()
            };

            return View("Index", viewModel);
        }

        // Eliminar
        public IActionResult Eliminar(int id)
        {
            var inventario = _context.Inventario.Find(id);
            if (inventario == null) return NotFound();

            _context.Inventario.Remove(inventario);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
