using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcProyectoWeb.Models.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Slider> Sliders { get; set; }        

        //Páginación del inicio
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
    }
}
