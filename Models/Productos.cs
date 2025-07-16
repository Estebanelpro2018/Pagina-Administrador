using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagina_Administrador.Models
{
    [Table("productos")]
    public class Producto
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("titulo")]
        public string Titulo { get; set; }

        [Column("imagen")]
        public string Imagen { get; set; }

        [Required]
        [Column("precio")]
        public decimal Precio { get; set; }

        [Column("ratingCount")]
        public string RatingCount { get; set; }

        [Column("bestSeller")]
        public string BestSeller { get; set; }

        [Column("detalles")]
        public string Detalles { get; set; }

        [Column("acercaDe")]
        public string AcercaDe { get; set; }

        [Column("id_categoria")]
        public int? IdCategoria { get; set; }

        [Column("stock")]
        public int? Stock { get; set; }
    }
}
