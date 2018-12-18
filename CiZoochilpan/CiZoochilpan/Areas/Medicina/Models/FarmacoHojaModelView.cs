using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CiZoochilpan.Areas.Medicina.Models
{
    public class FarmacoHojaModelView
    {
        public int idClinica { get; set; }
        public int idFarmaco { get; set; }
        public string nombreFarmaco { get; set; }
        public string via { get; set; }
        public string dosis { get; set; }
        public string frecuencia { get; set; }
        public string fechaAplicacion { get; set; }


    }
}