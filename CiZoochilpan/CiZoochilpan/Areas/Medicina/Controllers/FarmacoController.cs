using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CiZoochilpan.Areas.Medicina.Models;
using System.Data;
using System.Threading.Tasks;
using System.Net.Http;
namespace CiZoochilpan.Areas.Medicina.Controllers
{
    public class FarmacoController : Controller
    {
        // GET: Medicina/Farmaco
        public async Task<ActionResult> Index(string textoBuscar)
        {
            IEnumerable<FarmacoModelView> lstFarmacos = null;
            using (var client = new HttpClient())
            {
                if (textoBuscar == string.Empty || textoBuscar == null)
                {
                    client.BaseAddress = new Uri("http://tanathoz-001-site1.ctempurl.com/api/");
                    var responseTask = client.GetAsync("Farmaco");
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<FarmacoModelView>>();
                        readTask.Wait();
                        lstFarmacos = readTask.Result;
                    }
                    else
                    {
                        lstFarmacos = Enumerable.Empty<FarmacoModelView>();
                        ModelState.AddModelError(string.Empty, "Error al obtener los farmacos");

                    }
                }else
                {
                    client.BaseAddress = new Uri("http://tanathoz-001-site1.ctempurl.com/api/");
                    var responseTask = client.GetAsync("Farmaco?valor="+textoBuscar);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<FarmacoModelView>>();
                        readTask.Wait();
                        lstFarmacos = readTask.Result;
                    }else
                    {
                        lstFarmacos = Enumerable.Empty<FarmacoModelView>();
                        ModelState.AddModelError(string.Empty, "Error al obtener los farmacos");
                    }
                }


            }
                return View(lstFarmacos);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create( FarmacoModelView farmaco)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathoz-001-site1.ctempurl.com/api/Farmaco");
                var postTask = client.PostAsJsonAsync<FarmacoModelView>("Farmaco",farmaco);
                postTask.Wait();
                var resul = postTask.Result;
                if (resul.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Se ha registrado un farmaco de forma exitosa";
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Sever error. error al intentar registrar ");
            TempData["Error"] = "Ha ocurrido un error al intetar registrar ";
            return View(farmaco);

        }

        public ActionResult Edit(int id)
        {
            FarmacoModelView farmaco = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathoz-001-site1.ctempurl.com/api/");
                var responseTask = client.GetAsync("Farmaco?id="+id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<FarmacoModelView>();
                    readTask.Wait();
                    farmaco = readTask.Result;
                }
            }
            return View(farmaco);
        }

        [HttpPost]
        public ActionResult Edit(FarmacoModelView farmaco)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathoz-001-site1.ctempurl.com/api/Farmaco");
                var putTask = client.PutAsJsonAsync<FarmacoModelView>("Farmaco", farmaco);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Se ha editado un farmaco de forma exitosa";
                    return RedirectToAction("Index");
                }


            }
            TempData["Error"] = "Ha Ocurrido un error al intentar actualizar ";
            return View(farmaco);
        }

        public ActionResult Delete (int id)
        {
         
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathoz-001-site1.ctempurl.com/api/");
                var deleteTask = client.DeleteAsync("Farmaco/" + id.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Se ha eliminado un farmaco correctamente";
                    return RedirectToAction("Index");
                }
            }

            TempData["Error"] = "Ha Ocurrido un error al Eliminar ";
            return RedirectToAction("Index");
        }


    }
}