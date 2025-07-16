using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Pagina_Administrador.Models;

namespace Pagina_Administrador
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 💾 Conexión a MySQL
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Servicios MVC + Sesión
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(); // ← habilita el servicio de sesiones

            var app = builder.Build();

            // Configuración del pipeline HTTP
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession(); // ← activa el middleware de sesiones

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Auth}/{action=Login}/{id?}"); // ← arranca en Login

            app.Run();
        }
    }
}
