using Microsoft.AspNetCore.Mvc;
using Pagina_Administrador.Models;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Pagina_Administrador.Models;
using System.Linq;

namespace Pagina_Administrador.Controllers
{
    public class CompraController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompraController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Mostrar formulario (crear o editar) + lista de compras
        public IActionResult Index(int? id)
        {
            var compra = id.HasValue ? _context.Compras.Find(id.Value) : new Compra();

            var viewModel = new CompraViewModel
            {
                Compra = compra ?? new Compra(),
                ListaCompras = _context.Compras.ToList()
            };

            return View(viewModel);
        }

        // Crear nueva compra
        [HttpPost]
        public IActionResult Crear(Compra compra)
        {
            if (ModelState.IsValid)
            {
                _context.Compras.Add(compra);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            var viewModel = new CompraViewModel
            {
                Compra = compra,
                ListaCompras = _context.Compras.ToList()
            };

            return View("Index", viewModel);
        }

        // Editar compra existente
        [HttpPost]
        public IActionResult Editar(Compra compra)
        {
            if (ModelState.IsValid)
            {
                _context.Compras.Update(compra);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            var viewModel = new CompraViewModel
            {
                Compra = compra,
                ListaCompras = _context.Compras.ToList()
            };

            return View("Index", viewModel);
        }

        // Eliminar compra
        public IActionResult Eliminar(int id)
        {
            var compra = _context.Compras.Find(id);
            if (compra == null) return NotFound();

            _context.Compras.Remove(compra);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
