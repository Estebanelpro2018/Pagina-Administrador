using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagina_Administrador.Models
{
    [Table("inventario")]
    public class Inventario
    {
        [Key]
        [Column("id_producto")]
        public int IdProducto { get; set; }

        [Column("stock_actual")]
        public int StockActual { get; set; }
    }
}
