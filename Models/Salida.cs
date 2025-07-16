using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagina_Administrador.Models
{
    [Table("salidas")]
    public class Salida
    {
        [Key]
        [Column("id_salida")]
        public int IdSalida { get; set; }

        [Column("id_producto")]
        public int? IdProducto { get; set; }

        [Column("cantidad")]
        public int Cantidad { get; set; }

        [Column("fecha")]
        public DateTime? Fecha { get; set; }
    }
}
