using System.Collections.Generic;
using Pagina_Administrador.Models;

namespace Pagina_Administrador.Models
{
    public class DetalleCompraViewModel
    {
        public DetalleCompra DetalleCompra { get; set; } = new DetalleCompra();
        public List<DetalleCompra> ListaDetalleCompra { get; set; } = new List<DetalleCompra>();
    }
}
