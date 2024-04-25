using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mvcProyectoWeb.Models;

namespace mvcProyectoWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Poner aquí todos los modelos que se vayan creando
        public DbSet<Almacen> Almacen { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Slider> Slider { get; set; }
    }
}
