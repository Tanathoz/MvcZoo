using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CiZoochilpan.Areas.Animales.Models
{
    public class Familia
    {
        [Required(ErrorMessage ="Debes de seleccionar el orden al que pertenece la familia")]
        public string idOrden { get; set; }
        public int idFam { get; set; }
        [MaxLength(30, ErrorMessage = "La longitud máxima del nombre es de 30")]
        [MinLength(2, ErrorMessage = "La longitud minima del nombre  es de 2")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "nombre solo permite letras")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string nombre { get; set; }

    }
}