using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CiZoochilpan.Areas.Animales.Models
{
    public class Especie
    {
        
        public int id { get; set; }
        [Required(ErrorMessage = "Debes seleccionar una familia")]
        public int idFamilia { get; set; }
        [Required(ErrorMessage = "Debes ingresar el nombre de la especie")]
        [MaxLength (30,ErrorMessage = "La longitud La longitud máxima del nombre es de 30")]
        [MinLength (2, ErrorMessage = "La longitud minima del nombre es de 2")]
        [RegularExpression ("^[a-zA-Z ]*$",ErrorMessage = "Nombre solo permite letras" )]
        public string nombre { get; set; }


    }
}