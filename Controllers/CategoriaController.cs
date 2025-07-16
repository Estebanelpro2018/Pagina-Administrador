using Microsoft.AspNetCore.Mvc;
using Pagina_Administrador.Models;
using System.Linq;

namespace Pagina_Administrador.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? id)
        {
            var categoria = id.HasValue ? _context.Categorias.Find(id.Value) : new Categoria();

            var viewModel = new CategoriaViewModel
            {
                Categoria = categoria ?? new Categoria(),
                ListaCategorias = _context.Categorias.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Crear(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Categorias.Add(categoria);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            var viewModel = new CategoriaViewModel
            {
                Categoria = categoria,
                ListaCategorias = _context.Categorias.ToList()
            };

            return View("Index", viewModel);
        }

        [HttpPost]
        public IActionResult Editar(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Categorias.Update(categoria);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            var viewModel = new CategoriaViewModel
            {
                Categoria = categoria,
                ListaCategorias = _context.Categorias.ToList()
            };

            return View("Index", viewModel);
        }

        public IActionResult Eliminar(int id)
        {
            var categoria = _context.Categorias.Find(id);
            if (categoria == null)
                return NotFound();

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
