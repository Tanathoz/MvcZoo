using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CiZoochilpan.Areas.Medicina.Models
{
    public class FarmacoModelView
    {
        [Required(ErrorMessage ="el id es obligatorio")]
        public int id { get; set; }
        [Required (ErrorMessage ="El nombre del farmaco es obligatorio")]
        [MaxLength(30,ErrorMessage ="La longitud máxima del nombre es 30 caracteres")]
        [MinLength(3, ErrorMessage ="La longitud minima del nombre es 3 caracteres")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "El campo via del farmaco es obligatorio")]
        [MaxLength(30, ErrorMessage = "La longitud máxima del campo via es 30 caracteres")]
        [MinLength(3, ErrorMessage = "La longitud minima del campo via es 3 caracteres")]
        public string via { get; set; }


    }
}