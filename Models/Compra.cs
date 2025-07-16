using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagina_Administrador.Models
{
    [Table("compras")]
    public class Compra
    {
        [Key]
        [Column("id_compra")]
        public int IdCompra { get; set; }

        [Column("id_usuario")]
        public int? IdUsuario { get; set; }

        [Column("estado")]
        public string Estado { get; set; }

        [Column("fecha")]
        public DateTime? Fecha { get; set; }

        [Column("total")]
        public decimal? Total { get; set; }
    }
}
