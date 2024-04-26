using Microsoft.AspNetCore.Mvc;
using mvcDropdown.Datos;
using mvcDropdown.Models;
using System.Diagnostics;

namespace mvcDropdown.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _contexto;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext contexto)
        {
            _logger = logger;
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            var sucursales = _contexto.Sucursal.ToList();

            var viewModel = new DropDownsVM
            {
                Sucursales = sucursales
            };

            return View(viewModel);
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


        [HttpGet]
        public JsonResult ObtenerCategorias(int sucursalId)
        {
            var categorias = _contexto.Categoria.Where(c => c.SucursalId == sucursalId).ToList();
            return Json(categorias);
        }

        [HttpGet]
        public JsonResult ObtenerProductos(int categoriaId)
        {
            var productos = _contexto.Producto.Where(c => c.CategoriaId == categoriaId).ToList();
            return Json(productos);
        }
    }
}
