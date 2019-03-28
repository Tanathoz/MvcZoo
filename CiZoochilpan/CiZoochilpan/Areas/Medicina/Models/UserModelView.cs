using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CiZoochilpan.Areas.Medicina.Models
{
    public class UserModelView
    {
        public string id { get; set; }
        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        [MaxLength(50 , ErrorMessage ="La longitud máxima del usuario es 50")]
        [MinLength(2, ErrorMessage ="La longitud minima del usuario es 3")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "El email es obligatorio")]
        [MaxLength(50, ErrorMessage = "La longitud máxima del email es 50")]
        [MinLength(2, ErrorMessage = "La longitud minima del email es 3")]
        [EmailAddress (ErrorMessage ="debe ingresar un correo válido")]
        public string email { get; set; }
        [Required(ErrorMessage = "El password es obligatorio")]
        [MaxLength(50, ErrorMessage = "La longitud máxima del password es 50")]
        [MinLength(2, ErrorMessage = "La longitud minima del passsword es 3")]
        public string password { get; set; }



    }
}