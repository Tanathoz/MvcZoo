using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CiZoochilpan.Areas.Animales.Controllers
{
    public class FamiliaController : Controller
    {
        // GET: Animales/Familia
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}