using Microsoft.AspNetCore.Mvc;
using Pagina_Administrador.Models;
using System.Linq;

namespace Pagina_Administrador.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClienteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Mostrar formulario (crear o editar) + lista de clientes
        public IActionResult Index(int? id)
        {
            var cliente = id.HasValue ? _context.Clientes.Find(id.Value) : new Cliente();

            var viewModel = new ClienteViewModel
            {
                Cliente = cliente ?? new Cliente(),
                ListaClientes = _context.Clientes.ToList()
            };

            return View(viewModel);
        }

        // Crear nuevo cliente
        [HttpPost]
        public IActionResult Crear(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            var viewModel = new ClienteViewModel
            {
                Cliente = cliente,
                ListaClientes = _context.Clientes.ToList()
            };

            return View("Index", viewModel);
        }

        // Editar cliente existente
        [HttpPost]
        public IActionResult Editar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Clientes.Update(cliente);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            var viewModel = new ClienteViewModel
            {
                Cliente = cliente,
                ListaClientes = _context.Clientes.ToList()
            };

            return View("Index", viewModel);
        }

        // Eliminar cliente
        public IActionResult Eliminar(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null) return NotFound();

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
