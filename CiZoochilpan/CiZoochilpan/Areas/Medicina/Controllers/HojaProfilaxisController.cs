using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using CiZoochilpan.Areas.Medicina.Models;

namespace CiZoochilpan.Areas.Medicina.Controllers
{
    public class HojaProfilaxisController : Controller
    {
        // GET: Medicina/HojaProfilaxis
        public async Task<ActionResult> Index(string textoBuscar)
        {
            IEnumerable<HojaProfilaxisModelView> lstHojaProfilaxis = null;
            using (var client = new HttpClient())
            {
                if (textoBuscar == string.Empty || textoBuscar == null)
                {
                    client.BaseAddress = new Uri("http://tanathos-001-site1.dtempurl.com/api/");
                    var responseTask = client.GetAsync("HojaProfilaxis");
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<HojaProfilaxisModelView>>();
                        readTask.Wait();
                        lstHojaProfilaxis = readTask.Result;
                    }
                    else
                    {
                        lstHojaProfilaxis = Enumerable.Empty<HojaProfilaxisModelView>();
                        ModelState.AddModelError(string.Empty, "Error al obtener datos de la hoja profilaxis");
                    }
                }
                else
                {
                    client.BaseAddress = new Uri("http://tanathos-001-site1.dtempurl.com/api/");
                    var responseTask = client.GetAsync("HojaProfilaxis?valor=" + textoBuscar);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<HojaProfilaxisModelView>>();
                        responseTask.Wait();
                        lstHojaProfilaxis = readTask.Result;
                    }
                    else
                    {
                        lstHojaProfilaxis = Enumerable.Empty<HojaProfilaxisModelView>();
                        ModelState.AddModelError(string.Empty, "Ha ocurrido un error al obtener los datos de la hoja de Profilaxis");
                    }
                }

                return View(lstHojaProfilaxis);
            }
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProfilaxisAndFarmaco hoja)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathos-001-site1.dtempurl.com/api/HojaProfilaxis");
                var postTask = client.PostAsJsonAsync<HojaProfilaxisModelView>("HojaProfilaxis", hoja.hojas);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Se ha registrado una hoja de  profilaxis";
                    return RedirectToAction("Index");

                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. contacta con el administrador");
            TempData["Error"] = "Ha Ocurrido un error al intentar guardar ";
            return RedirectToAction("Index");
        }
        
        public ActionResult Edit(int id)
        {
            HojaProfilaxisModelView hoja = null;
            ProfilaxisAndFarmaco ProFar = new ProfilaxisAndFarmaco();
            FarmacoProfilaxisModelView farmaco = new FarmacoProfilaxisModelView();

            using ( var client =new  HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathos-001-site1.dtempurl.com/api/");
                var responseTask = client.GetAsync("HojaProfilaxis?id="+ id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<HojaProfilaxisModelView>();
                    readTask.Wait();
                    hoja = readTask.Result;
                    ProFar.hojas = new HojaProfilaxisModelView()
                    {
                        id = id,
                        lugar = hoja.lugar.ToString(),
                        fecha = hoja.fecha.ToString(),
                        marcaje = hoja.marcaje.ToString(),
                        tratamiento = hoja.tratamiento.ToString(),
                        fechaAplicacion = hoja.fechaAplicacion.ToString(),
                        observaciones = hoja.observaciones.ToString(),
                        fechaProxima = hoja.fechaProxima.ToString(),
                        idVeterinario = Convert.ToInt32(hoja.idVeterinario)

                    };
                }
            }
            return View(ProFar);
        }
        
        [HttpPost]
        public ActionResult Edit(ProfilaxisAndFarmaco hoja)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathos-001-site1.dtempurl.com/api/HojaProfilaxis");
                var putTask = client.PutAsJsonAsync<HojaProfilaxisModelView>("HojaProfilaxis", hoja.hojas);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Se ha editado una hoja de profilaxis de forma exitosa";
                    return RedirectToAction("Index");
                }
            }
            TempData["Error"] = "Ha Ocurrido un error al intentar actualizar ";
            return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult EditarFarmaco(string idClinica, string idFarmaco, string dosis, string frecuencia, string fechaAplicacion)
        {
            FarmacoProfilaxisModelView farmaco = new FarmacoProfilaxisModelView()
            {
                idProfilaxis = Convert.ToInt32(idClinica),
                idFarmaco = Convert.ToInt32(idFarmaco),
                dosis = dosis,
                frecuencia = frecuencia,
                fechaAplicacion = fechaAplicacion

            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("");
                var putTask = client.PutAsJsonAsync<FarmacoProfilaxisModelView>("HojaProfilaxis",farmaco );
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Se ha editado una hoja de profilaxis exitosamente";
                    return View();
                }
            }
            TempData["Error"] = "Ha Ocurrido un error al intentar actualizar";
            return View();

        }
         
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49770/api/");
                var deleteTask = client.DeleteAsync("HojaProfilaxis/"+id.ToString());
                 deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Se ha eliminado una hoja de profilaxis exitosamente";
                    return RedirectToAction("Index");
                }

            }

            TempData["Error"] = "Ha ocurrido un error al intentar eliminar";
            return RedirectToAction("Index");
        }
    }
}