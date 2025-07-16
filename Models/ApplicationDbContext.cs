using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Pagina_Administrador.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Carrito> Carrito { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<DetalleCompra> DetalleCompra { get; set; }
        public DbSet<Entrada> Entradas { get; set; }
        public DbSet<Inventario> Inventario { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<QuienesSomos> QuienesSomos { get; set; }
        public DbSet<Salida> Salidas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
