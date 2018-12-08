using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CiZoochilpan.Areas.Dietas.Models
{
    public class DietaEjemplarModelView
    {
        [Required(ErrorMessage = "Seleccionar ejemplar es obligatorio ")]
        public string marcaje { get; set; }
        public string nombreComun { get; set; }
        public string nombrePropio { get; set; }
        public string fechaCambio { get; set; }
        [Required(ErrorMessage ="El campo de causa cambio es obligatorio")]
        [MinLength (5, ErrorMessage ="La longitud minima es de 5 caracteres")]
        [MaxLength (50, ErrorMessage ="La longituf máxima es de 50 caracteres")]
        public string causaCambio { get; set; }
        public string cantidad { get; set; }
        [Required(ErrorMessage ="El campo alimento es obligatorio")]
        [MinLength(5, ErrorMessage = "La longitud minima es de 5 caracteres")]
        [MaxLength(50, ErrorMessage = "La longituf máxima es de 50 caracteres")]
        public string alimento { get; set; }

        public string horario { get; set; }
        public string consideraciones { get; set;}

    }
}