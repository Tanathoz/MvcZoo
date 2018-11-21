using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CiZoochilpan.Areas.Medicina.Models
{
    public class VeterinarioViewModel
    {
        public int id { get; set; }
        //[Range(2,30, ErrorMessage ="La longitud del nombre debe ser mayor a 2 y menor a 30")]
        [Required(ErrorMessage = "EL nombre es obligatorio")]
        [MaxLength(30, ErrorMessage ="La longitud máxima del nombre es de 30")]
        [MinLength(2, ErrorMessage = "La longitud minima del nombre es de 2")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage= "Nombre solo permite letras")]
        public string nombre { get; set; }
        //[Range(2, 30, ErrorMessage = "La longitud del apellido paterno debe ser mayor a 2 y menor a 30")]
        [MaxLength(30, ErrorMessage = "La longitud máxima del apellido paterno es de 30")]
        [MinLength(2, ErrorMessage = "La longitud minima del apellido paterno es de 2")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "apellido paterno solo permite letras")]
        [Required(ErrorMessage = "El apellido paterno es obligatorio")]
        public string apellidoPaterno { get; set; }
        //[Range(2, 30, ErrorMessage = "La longitud del apellido materno debe ser mayor a 2 y menor a 30")]
        [MaxLength(30, ErrorMessage = "La longitud máxima del apellido materno es de 30")]
        [MinLength(2, ErrorMessage = "La longitud minima del apellido materno es de 2")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "apellido materno solo permite letras")]
        [Required(ErrorMessage ="El apellido materno es obligatorio")]
        public string apellidoMaterno { get; set; }
        public string sexo { get; set; }

        public string textoBuscar { get; set; }

    }
}