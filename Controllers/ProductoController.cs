using Microsoft.AspNetCore.Mvc;
using Pagina_Administrador.Models;
using System.Linq;

namespace Pagina_Administrador.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Mostrar productos + formulario (crear o editar si hay id)
        public IActionResult Index(int? id)
        {
            var producto = id.HasValue ? _context.Productos.Find(id.Value) : new Producto();

            var viewModel = new ProductoViewModel
            {
                Producto = producto ?? new Producto(),
                ListaProductos = _context.Productos.ToList()
            };

            return View(viewModel);
        }

        // Crear nuevo producto desde formulario en Index
        [HttpPost]
        public IActionResult Crear(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Productos.Add(producto);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            var viewModel = new ProductoViewModel
            {
                Producto = producto,
                ListaProductos = _context.Productos.ToList()
            };

            return View("Index", viewModel);
        }

        // Editar producto desde formulario en Index
        [HttpPost]
        public IActionResult Editar(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Productos.Update(producto);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            var viewModel = new ProductoViewModel
            {
                Producto = producto,
                ListaProductos = _context.Productos.ToList()
            };

            return View("Index", viewModel);
        }

        // Eliminar producto
        public IActionResult Eliminar(int id)
        {
            var producto = _context.Productos.Find(id);
            if (producto == null)
                return NotFound();

            _context.Productos.Remove(producto);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
