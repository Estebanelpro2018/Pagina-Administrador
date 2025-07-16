using Microsoft.AspNetCore.Mvc;
using Pagina_Administrador.Models;
using System.Linq;

namespace Pagina_Administrador.Controllers
{
    public class EntradaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EntradaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Mostrar formulario (crear o editar) + lista de entradas
        public IActionResult Index(int? id)
        {
            var entrada = id.HasValue ? _context.Entradas.Find(id.Value) : new Entrada();

            var viewModel = new EntradaViewModel
            {
                Entrada = entrada ?? new Entrada(),
                ListaEntradas = _context.Entradas.ToList()
            };

            return View(viewModel);
        }

        // Crear nueva entrada
        [HttpPost]
        public IActionResult Crear(Entrada entrada)
        {
            if (ModelState.IsValid)
            {
                _context.Entradas.Add(entrada);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            var viewModel = new EntradaViewModel
            {
                Entrada = entrada,
                ListaEntradas = _context.Entradas.ToList()
            };

            return View("Index", viewModel);
        }

        // Editar entrada existente
        [HttpPost]
        public IActionResult Editar(Entrada entrada)
        {
            if (ModelState.IsValid)
            {
                _context.Entradas.Update(entrada);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            var viewModel = new EntradaViewModel
            {
                Entrada = entrada,
                ListaEntradas = _context.Entradas.ToList()
            };

            return View("Index", viewModel);
        }

        // Eliminar entrada
        public IActionResult Eliminar(int id)
        {
            var entrada = _context.Entradas.Find(id);
            if (entrada == null) return NotFound();

            _context.Entradas.Remove(entrada);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
