using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mvcProyectoWeb.Data;
using mvcProyectoWeb.Models;
using mvcProyectoWeb.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcProyectoWeb.AccesoDatos.Data.Inicializador
{
    public class InicializadorBD : IInicializadorBD
    {
        private readonly ApplicationDbContext _bd;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        //Creamos el constructor
        public InicializadorBD(ApplicationDbContext bd, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _bd = bd;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Inicializar()
        {
            try
            {
                if (_bd.Database.GetPendingMigrations().Count() > 0)
                {
                    _bd.Database.Migrate();
                }
            }
            catch (Exception)
            {
            }

            if (_bd.Roles.Any(ro => ro.Name == CNT.Administrador)) return;

            //Creación de roles
            _roleManager.CreateAsync(new IdentityRole(CNT.Administrador)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(CNT.Registrado)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(CNT.Cliente)).GetAwaiter().GetResult();

            //Creación del usuario inicial
            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "davidserrudo@gmail.com",
                Email = "davidserrudo@gmail.com",
                EmailConfirmed = true,
                Nombre = "David"
            }, "Hola123$").GetAwaiter().GetResult();

            ApplicationUser usuario = _bd.ApplicationUser.Where(us => us.Email == "davidserrudo@gmail.com").FirstOrDefault();
            _userManager.AddToRoleAsync(usuario, CNT.Administrador).GetAwaiter().GetResult();

            //Cupones de descuento para cualquiera de mis cursos: joseandresmont@gmail.com
        }
    }
}
