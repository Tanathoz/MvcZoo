using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CiZoochilpan.Areas.Medicina.Models
{
    public class HojaProfilaxisModelView
    {

        public int id { get; set; }
        [Required(ErrorMessage = "El campo lugar es obligatorio")]
        [MaxLength(100, ErrorMessage = "la longitud máxima del campo lugar es de 100 caracteres")]
        [MinLength(10, ErrorMessage = "la longitud mínima del campo lugar es de 10 caracteres")]
        public string lugar { get; set; }

        [Required(ErrorMessage = "El campo fecha es obligatorio")]
        [DataType(DataType.Date)]
        public string fecha { get; set; }
        [Required(ErrorMessage = "El campo tratamiento es obligatorio")]
        public string tratamiento { get; set; }
        public string observaciones { get; set; }

        [DataType(DataType.Date)]
        public string fechaAplicacion { get; set; }
        [DataType(DataType.Date)]
        public string fechaProxima { get; set; }
        
        public string marcaje { get; set; }
        public string nombrePropio { get; set; }
        public string nombreComun { get; set; }
        [Required(ErrorMessage = "El campo fecha es obligatorio")]
        public int idVeterinario { get; set; }

    }
}