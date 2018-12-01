using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CiZoochilpan.Areas.Animales.Models
{
    public class EjemplarViewModel
    {
        [Required (ErrorMessage ="EL marcaje es obligatorio ")]
        [MaxLength (30, ErrorMessage ="La longitud máxima del marcaje es 30")]
        [MinLength (5,ErrorMessage = "La longitud minima del marcaje es 5")]
        public string marcaje { get; set; }
        [Required(ErrorMessage = "Es obligatorio seleccionar animal")]
        public int idAnimal { get; set; }
        public string nombreComun { get; set; }
        public string fechaNacimiento { get; set; }
        [Required(ErrorMessage = "La fecha de alta es obligatoria ")]
        public string fechaAlta { get; set; }
        [Required(ErrorMessage = "El sexo es obligario")]
        public string sexo { get; set; }
        public string nombrePropio { get; set; }
    



    }
}