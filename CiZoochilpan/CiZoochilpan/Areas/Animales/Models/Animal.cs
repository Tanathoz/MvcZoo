using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CiZoochilpan.Areas.Animales.Models
{
    public class Animal
    {
        public int id { get; set; }
        [Required (ErrorMessage ="El nombre cientifico es obligatorio")]
        [MaxLength (50, ErrorMessage ="La longitud máxima del nombre cientifico es de 50 ")]
        [MinLength (3, ErrorMessage ="La longitud minima del nombre cientifico es de 3")]
        [RegularExpression ("^[a-zA-Z ]*$", ErrorMessage = "Nombre cientifico solo permite letras")]
        public string nombreCientifico { get; set; }
        [Required (ErrorMessage ="El nombre común es obligatorio ")]
        [MaxLength(50, ErrorMessage = "La longitud máxima del nombre común es de 50 ")]
        [MinLength(3, ErrorMessage = "La longitud minima del nombre común es de 3")]
        [RegularExpression ("^[a-zA-Z ]*$", ErrorMessage ="Nombre común solo permite letras")]
        public string nombreComun { get; set; }
        [Required (ErrorMessage ="Es obligatorio seleccionar orden")]
        public string orden { get; set; }
        [Required(ErrorMessage = "Es obligatorio seleccionar clase")]
        public string clase { get; set; }
        [Required(ErrorMessage = "Es obligatorio seleccionar familia")]
        public string familia { get; set; }
        [Required(ErrorMessage = "Es obligatorio seleccionar especie")]
        public string especie { get; set; }
        [Required(ErrorMessage = "Es obligatorio seleccionar habitat")]
        public string habitat { get; set; }
        public string gestacion { get; set; }
        public string camada { get; set; }
        public string longevidad { get; set; }
        public string peso { get; set; }
        public string ubicacionGeografica { get; set; }
        public string alimentacion { get; set; }
    }
}