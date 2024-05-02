using mvcProyectoWeb.AccesoDatos.Data.Repository.IRepository;
using mvcProyectoWeb.Data;
using mvcProyectoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace mvcProyectoWeb.AccesoDatos.Data.Repository
{
    public class ProductoRepository : Repository<Producto>, IProductoRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IQueryable<Producto> AsQueryable()
        {
            return _db.Set<Producto>().AsQueryable();
        }

        public void Update(Producto producto)
        {
            var objDesdeDb = _db.Producto.FirstOrDefault(s => s.Id == producto.Id);
            objDesdeDb.Nombre = producto.Nombre;
            objDesdeDb.Descripcion = producto.Descripcion;
            objDesdeDb.UrlImagen = producto.UrlImagen;
            objDesdeDb.CategoriaId = producto.CategoriaId;
            //_db.SaveChanges();
        }
    }
}
