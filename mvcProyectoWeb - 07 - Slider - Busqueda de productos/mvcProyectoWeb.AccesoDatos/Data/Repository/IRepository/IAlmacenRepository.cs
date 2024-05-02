using mvcProyectoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace mvcProyectoWeb.AccesoDatos.Data.Repository.IRepository
{
    public interface IAlmacenRepository :IRepository<Almacen>   
    {
        void Update(Almacen almacen);
        IEnumerable<SelectListItem> GetListaAlmacenes();
    }
}
