using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CiZoochilpan.Areas.Medicina.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace CiZoochilpan.Areas.Medicina.Controllers
{
    public class VeterinarioController : Controller
    {
        // GET: Medicina/Veterinario
        public async Task<ActionResult> Index(string textoBuscar )
        {
             IEnumerable<VeterinarioViewModel> lstVeterinario = null;           
             using (var client = new HttpClient())
             {

                if (textoBuscar == string.Empty || textoBuscar == null)
                {
                    client.BaseAddress = new Uri("http://tanathoz-001-site1.ctempurl.com/api/");
                    //HTTP GET
                    var responseTask = client.GetAsync("Veterinario");
                     responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<VeterinarioViewModel>>();
                        readTask.Wait();
                        lstVeterinario = readTask.Result;
                        Console.WriteLine("Exito al consultar la Api");
                    }
                    else
                    {
                        lstVeterinario = Enumerable.Empty<VeterinarioViewModel>();
                        ModelState.AddModelError(string.Empty, "Error al obtener los datos de los veterinarios");
                        Console.WriteLine("Error al obtener los datos");
                    }
                }
                else
                {
                    client.BaseAddress = new Uri("http://tanathoz-001-site1.ctempurl.com/api/");
                    var responseTask = client.GetAsync("Veterinario?valor=" + textoBuscar);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<VeterinarioViewModel>>();
                        readTask.Wait();
                        lstVeterinario = readTask.Result;
                        Console.WriteLine("Exito al consultar la Api");
                    }
                    else
                    {
                        lstVeterinario = Enumerable.Empty<VeterinarioViewModel>();
                        ModelState.AddModelError(string.Empty, "Error al obtener los datos de los veterinarios");
                        Console.WriteLine("Error al obtener los datos");
                    }
                }

              
                
             }

             return View(lstVeterinario); 
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(VeterinarioViewModel veterinario)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathoz-001-site1.ctempurl.com/api/Veterinario");
                //HTTP POST
                var postTask = client.PostAsJsonAsync<VeterinarioViewModel>("Veterinario", veterinario);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Se ha registrado un veterinario de forma exitosa";
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. contacta con el administrador");
            TempData["Error"] = "Ha Ocurrido un error al intentar guardar ";
            return View(veterinario);
        }

        public ActionResult Edit(int id)
        {
            VeterinarioViewModel veterinario = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathoz-001-site1.ctempurl.com/api/");
                //HTTP Get
                var responseTask = client.GetAsync("Veterinario?id=" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<VeterinarioViewModel>();
                    readTask.Wait();
                    veterinario = readTask.Result;
                }

            }

            return View(veterinario);
        }

        [HttpPost]
        public ActionResult Edit(VeterinarioViewModel veterinario)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathoz-001-site1.ctempurl.com/api/Veterinario");
                //HTTP POST
                var putTask = client.PutAsJsonAsync<VeterinarioViewModel>("Veterinario", veterinario);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Se ha editado  un veterinario de forma exitosa";
                    return RedirectToAction("Index");
                }
            }

            TempData["Error"] = "Ha Ocurrido un error al intentar actualizar ";
            return View(veterinario);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathoz-001-site1.ctempurl.com/api/");
                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Veterinario/" + id.ToString());
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