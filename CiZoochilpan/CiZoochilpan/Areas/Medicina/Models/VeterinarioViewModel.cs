﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CiZoochilpan.Areas.Medicina.Models
{
    public class VeterinarioViewModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string sexo { get; set; }

    }
}