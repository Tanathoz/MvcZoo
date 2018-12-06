using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CiZoochilpan.Areas.Dietas.Models
{
    public class DietaModelView
    {
        [Required (ErrorMessage ="Es obligatorio seleccionar un animal")]
        public int idAnimal { get; set; }
        public string nombreComun { get; set;}
        [Required (ErrorMessage ="La cantidad es obligatoria")]
        [MaxLength (50,ErrorMessage ="La longitud máxima es de 50 caracteres")]
        [MinLength (3, ErrorMessage ="La longitud minima es de 3 caracteres")]
        public string cantidad { get; set; }
        [Required (ErrorMessage ="El campo alimento es obligatorio")]
        [MaxLength (50, ErrorMessage ="La longitud Máxima es de 50 caracteres")]
        [MinLength (3, ErrorMessage ="La longitud minima es de 3 caracteres")]
        public string alimento { get; set; }
        public string horario { get; set; }
        public string consideraciones { get; set; }
    }
}