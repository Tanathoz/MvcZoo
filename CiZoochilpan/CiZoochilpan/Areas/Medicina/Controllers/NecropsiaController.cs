using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using CiZoochilpan.Areas.Medicina.Models;
using System.Net.Http;

namespace CiZoochilpan.Areas.Medicina.Controllers
{
    public class NecropsiaController : Controller
    {
        // GET: Medicina/Necropsia
        public async Task<ActionResult> Index(string textoBuscar)
        {
            IEnumerable<NecropsiaModelView> lstNecropsia = null;
            using (var client = new HttpClient())
            {
                if (textoBuscar == string.Empty || textoBuscar == null)
                {
                    client.BaseAddress = new Uri("http://tanathos-001-site1.dtempurl.com/api/");
                    var responseTask = client.GetAsync("Necropsia");
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<NecropsiaModelView>>();
                        readTask.Wait();
                        lstNecropsia = readTask.Result;
                    }
                    else
                    {
                        lstNecropsia = Enumerable.Empty<NecropsiaModelView>();
                        ModelState.AddModelError(string.Empty, "Error al obtener datos de la necropsia");

                    }
                }
                else
                {
                    client.BaseAddress = new Uri("http://tanathos-001-site1.dtempurl.com/api/");
                    var responseTask = client.GetAsync("Necropsia?valor=" + textoBuscar);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<NecropsiaModelView>>();
                        responseTask.Wait();
                        lstNecropsia = readTask.Result;
                    }
                    else
                    {
                        lstNecropsia = Enumerable.Empty<NecropsiaModelView>();
                        ModelState.AddModelError(string.Empty, "Ha ocurrido un error al obtener los datos de la necropsia");
                    }
                }

                return View(lstNecropsia);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NecropsiaModelView necropsia)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathos-001-site1.dtempurl.com/api/Necropsia");
                var postTask = client.PostAsJsonAsync<NecropsiaModelView>("Necropsia", necropsia);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Se ha registrado una necropsia exitosamente";
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. contacta con el administrador ");
            TempData["Error"] = "Ha Ocurrido un error al intentar guardar ";
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            NecropsiaModelView necropsia = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathos-001-site1.dtempurl.com/api/");
                var responseTask = client.GetAsync("Necropsia?id=" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<NecropsiaModelView>();
                    readTask.Wait();
                    necropsia = readTask.Result;
                }
            }
            return View(necropsia);
        }

        [HttpPost]
        public ActionResult Edit(NecropsiaModelView necropsia)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathos-001-site1.dtempurl.com/api/Necropsia");
                var putTask = client.PutAsJsonAsync<NecropsiaModelView>("Necropsia", necropsia);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Se ha editado una Necropsia de forma exitosa";
                    return RedirectToAction("Index");
                }
            }

            TempData["Error"] = "Ha Ocurrido un error al intentar actualizat la necropsia";
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49770/api/");
                var deleteTask = client.DeleteAsync("Necropsia/"+id.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Se ha eliminado una Necropsia exitosamente";
                    return RedirectToAction("Index");

                }
            }
            TempData["Error"] = "Ha ocurrido un error al intentar eliminar";
            return RedirectToAction("Index");
        }
    }
}