using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Threading.Tasks;
using CiZoochilpan.Areas.Animales.Models;
using System.Net.Http;

namespace CiZoochilpan.Areas.Animales.Controllers
{
    public class EjemplarController : Controller
    {
        // GET: Animales/Ejemplar
        public async Task<ActionResult> Index( string textBuscar)
        {
            IEnumerable<EjemplarViewModel> lstEjemplares = null;
            using (var client = new HttpClient())
            {
                if (textBuscar == null || textBuscar == string.Empty)
                {
                    client.BaseAddress =new Uri("http://tanathos-001-site1.dtempurl.com/api/");
                    var responseTask = client.GetAsync("Ejemplar");
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<EjemplarViewModel>>();
                        readTask.Wait();
                        lstEjemplares = readTask.Result;
                    }
                    else
                    {
                        lstEjemplares = Enumerable.Empty<EjemplarViewModel>();
                        ModelState.AddModelError(string.Empty, "Error al obtener datos de ejemplar");

                    }
                }else
                {

                    client.BaseAddress = new Uri("http://tanathos-001-site1.dtempurl.com/api/");
                    var responseTask = client.GetAsync("Ejemplar?valor="+textBuscar);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<EjemplarViewModel>>();
                        readTask.Wait();
                        lstEjemplares = readTask.Result;

                    }else
                    {
                        lstEjemplares = Enumerable.Empty<EjemplarViewModel>();
                        ModelState.AddModelError(string.Empty, "Error al obtener los datos de los ejemplares");
                    }

                }


            }
                return View(lstEjemplares);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EjemplarViewModel ejemplar)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathos-001-site1.dtempurl.com/api/Ejemplar");
                var postTask = client.PostAsJsonAsync<EjemplarViewModel>("Ejemplar", ejemplar);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Se ha registrado un ejemplar de forma exitosa";
                    return RedirectToAction("Index");

                }
            }

            ModelState.AddModelError(string.Empty, "Erroe en el servidor consulta conel administrador");
            TempData["Error"] = "Ha ocurrido un error al intentar guardar";
            return View(ejemplar);
        }

        public ActionResult edit(string marcaje)
        {
            EjemplarViewModel ejemplar = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathos-001-site1.dtempurl.com/api/");
                var responseTask = client.GetAsync("Ejemplar?marcaje="+marcaje);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<EjemplarViewModel>();
                    readTask.Wait();
                    ejemplar = readTask.Result;

                }
            }
            return View(ejemplar);
        }

        [HttpPost]
        public ActionResult Edit(EjemplarViewModel ejemplar)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathos-001-site1.dtempurl.com/api/Ejemplar");
                var putTask = client.PutAsJsonAsync<EjemplarViewModel>("Ejemplar", ejemplar);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Se ha editado  un ejemplar de forma exitosa";
                    return RedirectToAction("Index");
                }
            }
            TempData["Error"] = "Ha Ocurrido un error al intentar actualizar ";
            return RedirectToAction("Index");
        }

        public ActionResult Delete (string marcajeDelete)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathos-001-site1.dtempurl.com/api/");
                var deleteTask = client.DeleteAsync("Ejemplar/?marcajeDelete=" + marcajeDelete.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Se ha eliminado un veterinario de forma exitosa";
                    return RedirectToAction("Index");
                }
            }
            TempData["Error"] = "Ha Ocurrido un error al Eliminar ";
            return RedirectToAction("Index");
        }

    }
}