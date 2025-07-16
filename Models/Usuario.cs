using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagina_Administrador.Models
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        [Column("id_usuario")]
        public int IdUsuario { get; set; }

        [Column("nombre_usuario")]
        public string NombreUsuario { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("clave")]
        public string Clave { get; set; }

        [Column("rol")]
        public string Rol { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
    }
}
