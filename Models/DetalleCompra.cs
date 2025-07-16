using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagina_Administrador.Models
{
    [Table("detalle_compra")]
    public class DetalleCompra
    {
        [Key]
        [Column("id_detalle")]
        public int IdDetalle { get; set; }

        [Column("id_compra")]
        public int? IdCompra { get; set; }

        [Column("id_producto")]
        public int? IdProducto { get; set; }

        [Column("cantidad")]
        public int Cantidad { get; set; }

        [Column("precio_unitario")]
        public decimal? PrecioUnitario { get; set; }
    }
}
