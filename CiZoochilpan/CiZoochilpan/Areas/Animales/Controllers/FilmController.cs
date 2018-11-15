using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using CiZoochilpan.Areas.Animales.Models;

namespace CiZoochilpan.Areas.Animales.Controllers
{
    public class FilmController : Controller
    {
        // GET: Animales/Film
        public ActionResult Index()
        {
            IEnumerable<FilmViewModel> lstFilms = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://ghibliapi.herokuapp.com/");
                //HTTP GET
                var responseTask = client.GetAsync("films");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<FilmViewModel>>();

                    readTask.Wait();
                    lstFilms = readTask.Result;
                }else
                {
                    lstFilms = Enumerable.Empty<FilmViewModel>();
                    ModelState.AddModelError(string.Empty, "Server  error. contact administrador");


                }
            }
                return View(lstFilms);
        }
    }
}