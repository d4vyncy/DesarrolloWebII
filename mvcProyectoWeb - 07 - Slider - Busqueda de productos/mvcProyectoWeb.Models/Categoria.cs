using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcProyectoWeb.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese un nombre para la categoría")]        
        public string Nombre { get; set; }        
    }
}
