using Microsoft.AspNetCore.Mvc;
using Pagina_Administrador.Models;
using System.Linq;

namespace Pagina_Administrador.Controllers
{
    public class SalidaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalidaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Mostrar formulario + lista de salidas
        public IActionResult Index(int? id)
        {
            var salida = id.HasValue ? _context.Salidas.Find(id.Value) : new Salida();

            var viewModel = new SalidaViewModel
            {
                Salida = salida ?? new Salida(),
                ListaSalidas = _context.Salidas.ToList()
            };

            return View(viewModel);
        }

        // Crear nueva salida
        [HttpPost]
        public IActionResult Crear(Salida salida)
        {
            if (ModelState.IsValid)
            {
                _context.Salidas.Add(salida);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            var viewModel = new SalidaViewModel
            {
                Salida = salida,
                ListaSalidas = _context.Salidas.ToList()
            };

            return View("Index", viewModel);
        }

        // Editar salida
        [HttpPost]
        public IActionResult Editar(Salida salida)
        {
            if (ModelState.IsValid)
            {
                _context.Salidas.Update(salida);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            var viewModel = new SalidaViewModel
            {
                Salida = salida,
                ListaSalidas = _context.Salidas.ToList()
            };

            return View("Index", viewModel);
        }

        // Eliminar salida
        public IActionResult Eliminar(int id)
        {
            var salida = _context.Salidas.Find(id);
            if (salida == null) return NotFound();

            _context.Salidas.Remove(salida);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
