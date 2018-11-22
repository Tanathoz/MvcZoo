using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using CiZoochilpan.Areas.Animales.Models;
namespace CiZoochilpan.Areas.Animales.Controllers
{
    public class EspecieController : Controller
    {
        // GET: Animales/Especie
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Especie especie)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathoz-001-site1.ctempurl.com/api/Especie");
                var postTask = client.PostAsJsonAsync<Especie>("Especie", especie);
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
            return View(especie);
        }


        public ActionResult PracticaApi()
        {
            IEnumerable<FilmViewModel> lstFilms = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://ghibliapi.herokuapp.com/");
                //HTTP GET
                var responseTask = client.GetAsync("fimls");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<FilmViewModel>>();

                    readTask.Wait();
                    lstFilms = readTask.Result;
                }
                else
                {
                    lstFilms = Enumerable.Empty<FilmViewModel>();
                    ModelState.AddModelError(string.Empty, "Server  error. contact administrador");


                }
            }
            return View(lstFilms);
            return View();
        }
    }
}