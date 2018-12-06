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
                    client.BaseAddress = new Uri("http://tanathoz-001-site1.ctempurl.com/api/");
                    var responseTask = client.GetAsync("Dieta");
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<DietaModelView>>();
                        readTask.Wait();
                        lstDietas = readTask.Result;
                    }
                    else
                    {
                        lstDietas = Enumerable.Empty<DietaModelView>();
                        ModelState.AddModelError(string.Empty, "Error al obtener datos del ejemplar");
                    }


                }else
                {
                    client.BaseAddress = new Uri("http://tanathoz-001-site1.ctempurl.com/api/");
                    var responseTask = client.GetAsync("Dieta?valor=" + textoBuscar.ToString());
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<DietaModelView>>();
                        readTask.Wait();
                        lstDietas = readTask.Result;
                    }
                    else
                    {
                        lstDietas = Enumerable.Empty<DietaModelView>();
                        ModelState.AddModelError(string.Empty, "Error al obtener la dieta");
                    }

                }
            }
                return View(lstDietas);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DietaModelView dieta)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathoz-001-site1.ctempurl.com/api/Dieta");
                var postTask = client.PostAsJsonAsync<DietaModelView>("Dieta", dieta);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Se ha registrado una dieta de animal exitosamente";
                    return RedirectToAction("Index");
                }
                
            }

            ModelState.AddModelError(string.Empty, "Error con el servidor al intentar guardar");
            TempData["Error"] = "Error al intentar guardar ";
            return RedirectToAction("Index");
        }
        
        public ActionResult Edit (int idAnimal)
        {
            DietaModelView dieta = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathoz-001-site1.ctempurl.com/api/");
                var responseTask = client.GetAsync("Dieta?id="+idAnimal.ToString());
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<DietaModelView>();
                    readTask.Wait();
                    dieta = readTask.Result;
                } 
            }
            return View(dieta);

        }

        [HttpPost]
        public ActionResult Edit(DietaModelView dieta)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathoz-001-site1.ctempurl.com/api/Dieta");
                var putTask = client.PutAsJsonAsync<DietaModelView>("Dieta",dieta);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Se ha editado una dieta de forma exitosamente";
                    return RedirectToAction("Index");
                }


            }
            TempData["Error"] = "Ha ocurrido un error al editor";
            return RedirectToAction("Index");

        }

        public ActionResult Delete (int idAnimal)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathoz-001-site1.ctempurl.com/api/");
                var deleteTask = client.DeleteAsync("Dieta/?idAnimal="+idAnimal.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Se ha eliminado una dieta de forma exitosa";
                    return RedirectToAction("Index");
                }
            }

            TempData["Error"] = "Ha ocurrido un error no es posible borrar";
            return RedirectToAction("Index");
        }


    }
}


