using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net.Http;
using CiZoochilpan.Areas.Dietas.Models;

namespace CiZoochilpan.Areas.Dietas.Controllers
{
    public class DietaController : Controller
    {
        // GET: Dietas/Dieta
        public async Task<ActionResult> Index(string textoBuscar)
        {
            IEnumerable<DietaModelView> lstDietas = null;
            using (var client = new HttpClient())
            {
                if (textoBuscar == null || textoBuscar == string.Empty)
                {

                }
            }
                return View();
        }
    }
}