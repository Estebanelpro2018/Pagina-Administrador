using Microsoft.AspNetCore.Mvc;
using Pagina_Administrador.Models;

public class DetalleCompraController : Controller
{
    private readonly ApplicationDbContext _context;

    public DetalleCompraController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Mostrar formulario + lista de detalles
    public IActionResult Index(int? id)
    {
        var detalle = id.HasValue ? _context.DetalleCompra.Find(id.Value) : new DetalleCompra();

        var viewModel = new DetalleCompraViewModel
        {
            DetalleCompra = detalle ?? new DetalleCompra(),
            ListaDetalleCompra = _context.DetalleCompra.ToList()
        };

        return View(viewModel);
    }

    // Crear o Editar en la misma acción
    [HttpPost]
    public IActionResult Guardar(DetalleCompra detalle)
    {
        if (ModelState.IsValid)
        {
            if (detalle.IdDetalle == 0)
            {
                _context.DetalleCompra.Add(detalle);
            }
            else
            {
                _context.DetalleCompra.Update(detalle);
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        var viewModel = new DetalleCompraViewModel
        {
            DetalleCompra = detalle,
            ListaDetalleCompra = _context.DetalleCompra.ToList()
        };

        return View("Index", viewModel);
    }

    // Eliminar
    public IActionResult Eliminar(int id)
    {
        var detalle = _context.DetalleCompra.Find(id);
        if (detalle == null) return NotFound();

        _context.DetalleCompra.Remove(detalle);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
