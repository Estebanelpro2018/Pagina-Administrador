using Microsoft.AspNetCore.Mvc;
using Pagina_Administrador.Models;
using System.Linq;

namespace Pagina_Administrador.Controllers
{
    public class QuienesSomosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuienesSomosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var contenido = _context.QuienesSomos.FirstOrDefault();

            if (contenido == null)
            {
                contenido = new QuienesSomos();
                _context.QuienesSomos.Add(contenido);
                _context.SaveChanges();
            }

            return View(contenido);
        }

        [HttpPost]
        public IActionResult Editar(QuienesSomos info)
        {
            if (ModelState.IsValid)
            {
                _context.QuienesSomos.Update(info);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Index", info);
        }
    }
}
