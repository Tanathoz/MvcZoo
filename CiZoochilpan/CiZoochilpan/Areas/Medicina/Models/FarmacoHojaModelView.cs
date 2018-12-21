using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CiZoochilpan.Areas.Medicina.Models
{
    public class FarmacoHojaModelView
    {
        [Required(ErrorMessage = "EL id de la hoja clinica es obligatoria")]
        public int idClinica { get; set; }
        [Required (ErrorMessage ="El id del farmaco es obligatorio")]
        public int idFarmaco { get; set; }
        public string nombreFarmaco { get; set; }
        public string via { get; set; }
        [Required (ErrorMessage ="el campo dosis es obligatorio")]
        public string dosis { get; set; }
        [Required (ErrorMessage ="El campo frecuencia es obligatorio")]
        public string frecuencia { get; set; }
        [DataType (DataType.Date)]
        public string fechaAplicacion { get; set; }


    }
}