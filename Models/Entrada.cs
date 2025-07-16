using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagina_Administrador.Models
{
    [Table("entradas")]
    public class Entrada
    {
        [Key]
        [Column("id_entrada")]
        public int IdEntrada { get; set; }

        [Column("id_producto")]
        public int? IdProducto { get; set; }

        [Column("cantidad")]
        public int Cantidad { get; set; }

        [Column("fecha")]
        public DateTime? Fecha { get; set; }
    }
}
