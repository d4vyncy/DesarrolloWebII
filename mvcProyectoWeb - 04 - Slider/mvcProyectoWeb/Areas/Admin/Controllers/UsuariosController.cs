using Microsoft.AspNetCore.Mvc;
using mvcProyectoWeb.AccesoDatos.Data.Repository.IRepository;
using mvcProyectoWeb.Models;
using System.Security.Claims;

namespace mvcProyectoWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsuariosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public UsuariosController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    //opcion 1 : obtener todos los usuarios
        //    return View(_contenedorTrabajo.Usuario.GetAll());
        //}
        [HttpGet]
        public IActionResult Index()
        {
            //opcion 2 : obtener todos los usuarios menos el que esta logueado
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var usuarioActual = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return View(_contenedorTrabajo.Usuario.GetAll(u => u.Id != usuarioActual.Value));
        }
        [HttpGet]
        public IActionResult Bloquear(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var usuarioActual = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            _contenedorTrabajo.Usuario.BloquearUsuario(id);
            return View("Index",_contenedorTrabajo.Usuario.GetAll(u => u.Id != usuarioActual.Value));
        }
        [HttpGet]
        public IActionResult Desbloquear(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var usuarioActual = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            _contenedorTrabajo.Usuario.Desbloquearusuario(id);
            return View("Index", _contenedorTrabajo.Usuario.GetAll(u => u.Id != usuarioActual.Value));
        }
    }
}
