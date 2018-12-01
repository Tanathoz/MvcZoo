using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CiZoochilpan.Areas.Animales.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace CiZoochilpan.Areas.Animales.Controllers
{
    public class AnimalController : Controller
    {
        // GET: Animales/Animal
        public async Task<ActionResult> Index(string textoBuscar)
        {
            IEnumerable<Animal> lstAnimales = null;
            using (var client = new HttpClient())
            {
                if (textoBuscar == string.Empty || textoBuscar == null)
                {
                    client.BaseAddress = new Uri("http://tanathoz-001-site1.ctempurl.com/api/");
                    //HTTP GET
                    var responseTask = client.GetAsync("Animal");
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<Animal>>();
                        readTask.Wait();
                        lstAnimales = readTask.Result;
                    }
                    else
                    {
                        lstAnimales = Enumerable.Empty<Animal>();
                        ModelState.AddModelError(string.Empty, "Error al obtener los datos");
                    }
                }
                else
                {
                    client.BaseAddress = new Uri("http://tanathoz-001-site1.ctempurl.com/api/");
                    var responseTask = client.GetAsync("Animal?valor=" + textoBuscar);
                    responseTask.Wait();
                    var result = responseTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<Animal>>();
                        readTask.Wait();
                        lstAnimales = readTask.Result;

                    }
                    else
                    {
                        lstAnimales = Enumerable.Empty<Animal>();
                        ModelState.AddModelError(string.Empty, "Error al obtener los datos");

                    }
                }
            }

            return View(lstAnimales);

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Animal animal)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathoz-001-site1.ctempurl.com/api/Animal");
                //HTTP post
                var postTakes = client.PostAsJsonAsync<Animal>("Animal", animal);
                postTakes.Wait();
                var result = postTakes.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Se ha registrado un nuevo animal exitosamente";
                    return RedirectToAction("Index");

                }
            }
            ModelState.AddModelError(string.Empty, "Server Error. no es posible registrar un nuevo animal");
            TempData["Error"] = "Ha Ocurrido un error al intentar guardar ";
            return View(animal);
        }

        public ActionResult Edit(int id)
        {
            Animal animal = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathoz-001-site1.ctempurl.com/api/");
                var responseTask = client.GetAsync("Animal?id=" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Animal>();
                    readTask.Wait();
                    animal = readTask.Result;
                }
            }
            return View(animal);
        }

        [HttpPost]
        public ActionResult Edit(Animal animal)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathoz-001-site1.ctempurl.com/api/Animal");
                var putTask = client.PutAsJsonAsync<Animal>("Animal", animal);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Se ha actualizado un animal exitosamente";
                    return RedirectToAction("Index");
                }
            }
            TempData["Error"] = "Ha ocurrido un error al intentar actualizar";
            return RedirectToAction("Index");
        }

        public ActionResult delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathoz-001-site1.ctempurl.com/api/");
                var deleteTask = client.DeleteAsync("Animal/?id=" + id.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Se ha eliminado un animal de forma exitosa";
                    return RedirectToAction("Index");
                }
            }
            TempData["Error"] = "Ha Ocurrido un error al Eliminar ";
            return RedirectToAction("Index");
        }

    }
}