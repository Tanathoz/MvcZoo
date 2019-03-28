using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CiZoochilpan.Areas.Animales.Models;
using System.Net.Http;
using System.Data;
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
        [HttpPost]
        public ActionResult Create( Familia familia)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathos-001-site1.dtempurl.com/api/Familia");
                var postTask = client.PostAsJsonAsync<Familia>("Familia", familia);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Se ha registrado una nueva familia exitosamente";
                    return RedirectToAction("Index", "Home",new { area = "" });

                }
            }
            ModelState.AddModelError(string.Empty, "Server Error. contacta con el administrador");
            TempData["Error"] = "Ha Ocurrido un error al intentar guardar ";
            return View(familia);
        } 
    }
}