using Microsoft.AspNetCore.Mvc;
using mvcProyectoWeb.AccesoDatos.Data.Repository;
using mvcProyectoWeb.AccesoDatos.Data.Repository.IRepository;
using mvcProyectoWeb.Models;
using mvcProyectoWeb.Models.ViewModels;
using System.Diagnostics;

namespace mvcProyectoWeb.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    public class HomeController : Controller
    {

        private readonly IContenedorTrabajo _contenedorTrabajo;
        public HomeController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        //Primera versi�n p�gina de inicio sin paginaci�n
        [HttpGet]
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                Sliders = _contenedorTrabajo.Slider.GetAll(),                
            };

            //Esta l�nea es para poder saber si estamos en el home o no
            ViewBag.IsHome = true;

            return View(homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
