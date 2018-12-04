using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CiZoochilpan.Areas.Dietas.Models
{
    public class DietaModelView
    {
        public int idAnimal { get; set; }
        public string cantidad { get; set; }
        public string alimento { get; set; }
        public string horario { get; set; }
        public string consideraciones { get; set; }
    }
}