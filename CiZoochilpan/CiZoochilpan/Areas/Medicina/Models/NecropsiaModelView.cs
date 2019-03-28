using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CiZoochilpan.Areas.Medicina.Models
{
    public class NecropsiaModelView
    {
        public int id { get; set; }
        [Required(ErrorMessage = "El campo lugar es obligatorio")]
        [MaxLength(100, ErrorMessage = "la longitud máxima del campo lugar es de 100 caracteres")]
        [MinLength(10, ErrorMessage = "la longitud mínima del campo lugar es de 10 caracteres")]
        public string lugar { get; set; }
        [Required(ErrorMessage = "El campo fecha es obligatorio")]
        [DataType(DataType.Date)]
        public string fecha { get; set; }
        [Required(ErrorMessage = "El campo marcaje es obligatorio")]
        public string marcaje { get; set; }
        public string nombrePropio { get; set; }
        public string nombreComun { get; set; }
        [Required(ErrorMessage = "El campo id veterinario es obligatorio")]
        public int idVeterinario { get; set; }

        [Required(ErrorMessage = "El campo id encargado es obligatorio")]
        public int idEncargado { get; set; }
        [DataType(DataType.Time)]
        public string hora { get; set; }
        public string antecedentes { get; set; }
        [Required(ErrorMessage = "El campo diagnostico es obligatorio")]
        public string diagnosticoMuerte { get; set; }
        public string estadoFisico { get; set; }
        public string lesiones { get; set; }
        public string toracica { get; set; }
        public string abdominal { get; set; }
        public string muestras { get; set; }

    }
}