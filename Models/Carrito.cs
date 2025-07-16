using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagina_Administrador.Models
{
    [Table("carrito")]
    public class Carrito
    {
        [Key]
        [Column("id_carrito")]
        public int IdCarrito { get; set; }

        [Column("id_usuario")]
        public int? IdUsuario { get; set; }

        [Column("id_producto")]
        public int? IdProducto { get; set; }

        [Column("cantidad")]
        public int Cantidad { get; set; }
    }
}
