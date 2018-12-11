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
    public class DietaEjemplarController : Controller
    {

        // GET: Dietas/DietaEjemplar
        public async Task<ActionResult> Index(string textoBuscar)
        {
            IEnumerable<DietaEjemplarModelView> lstDietas = null;
            using (var client = new HttpClient())
            {
                if (textoBuscar ==null || textoBuscar == string.Empty)
                {
                    client.BaseAddress = new Uri("http://tanathoz-001-site1.ctempurl.com/api/");
                    var responseTask = client.GetAsync("DietaEjemplar");
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<DietaEjemplarModelView>>();
                        readTask.Wait();
                        lstDietas = readTask.Result;
                    }else
                    {
                        lstDietas = Enumerable.Empty<DietaEjemplarModelView>();
                        ModelState.AddModelError(string.Empty, "Error al obtener datos de la dieta");

                    }
                }else
                {
                    client.BaseAddress = new Uri("http://tanathoz-001-site1.ctempurl.com/api/");
                    var responseTask = client.GetAsync("DietaEjemplar?valor=" + textoBuscar);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<DietaEjemplarModelView>>();
                        readTask.Wait();
                        lstDietas = readTask.Result;
                    }
                    else
                    {
                        lstDietas = Enumerable.Empty<DietaEjemplarModelView>();
                        ModelState.AddModelError(string.Empty, "Error al obtener datos de la dieta");
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
        public ActionResult Create(DietaEjemplarModelView dieta)
        {
            using (var client  = new HttpClient()){
                client.BaseAddress = new Uri("http://tanathoz-001-site1.ctempurl.com/api/DietaEjemplar");
                var postTask = client.PostAsJsonAsync<DietaEjemplarModelView>("DietaEjemplar",dieta);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Se ha registrado una dieta de ejemplar exitosamente";
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError(string.Empty, "Error con el servidor al intentar guardar");
                TempData["Error"] = "Error al intentar guardar ";
                return RedirectToAction("Index");


            }
        }
        public ActionResult Edit(string marcaje)
        {
            DietaEjemplarModelView dieta = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathoz-001-site1.ctempurl.com/api/");
                var responseTask = client.GetAsync("DietaEjemplar?marcaje=" + marcaje);
                responseTask.Wait();
                var result = responseTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<DietaEjemplarModelView>();
                    readTask.Wait();
                    dieta = readTask.Result;

                }
            }
            return View(dieta);
        }

        [HttpPost]
        public ActionResult Edit(DietaEjemplarModelView dieta)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathoz-001-site1.ctempurl.com/api/DietaEjemplar");
                var putTask = client.PutAsJsonAsync<DietaEjemplarModelView>("DietaEjemplar", dieta);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Se ha guardado una dieta de ejemplar exitosamente";
                    return RedirectToAction("Index");
                }
                TempData["Error"] = "Ha ocurrido un error al editor";
                return RedirectToAction("Index");

            }
        }

        public ActionResult Delete( string marcaje)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathoz-001-site1.ctempurl.com/api/");
                var deleteTask = client.DeleteAsync("DietaEjemplar/?marcaje="+marcaje);
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