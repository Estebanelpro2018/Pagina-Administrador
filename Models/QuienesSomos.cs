using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagina_Administrador.Models
{
    [Table("quienes_somos")]
    public class QuienesSomos
    {
        [Key]
        [Column("id_info")]
        public int IdInfo { get; set; }

        [Column("titulo")]
        public string Titulo { get; set; }

        [Column("descripcion")]
        public string Descripcion { get; set; }

        [Column("video_quienes_somos")]
        public string VideoQuienesSomos { get; set; }

        [Column("subtitulo1")]
        public string Subtitulo1 { get; set; }

        [Column("descripcion1")]
        public string Descripcion1 { get; set; }

        [Column("subtitulo2")]
        public string Subtitulo2 { get; set; }

        [Column("descripcion2")]
        public string Descripcion2 { get; set; }

        [Column("subtitulo3")]
        public string Subtitulo3 { get; set; }

        [Column("descripcion3")]
        public string Descripcion3 { get; set; }
    }
}
