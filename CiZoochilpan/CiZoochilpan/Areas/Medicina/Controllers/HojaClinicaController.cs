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
    public class HojaClinicaController : Controller
    {
        // GET: Medicina/HojaClinica
        public async  Task<ActionResult> Index(string textoBuscar)
        {
            IEnumerable<HojaClinicaModelView> lstHojaClinica = null;
            using (var client = new HttpClient())
            {
                if (textoBuscar == string.Empty || textoBuscar == null)
                {
                    client.BaseAddress = new Uri("http://tanathos-001-site1.dtempurl.com/api/");
                    var responseTask = client.GetAsync("HojaClinica");
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<HojaClinicaModelView>>();
                        readTask.Wait();
                        lstHojaClinica = readTask.Result;

                    }else
                    {
                        lstHojaClinica = Enumerable.Empty<HojaClinicaModelView>();
                        ModelState.AddModelError(string.Empty, "Error al obtener los datos del modelo");

                    }
                }else
                {
                    client.BaseAddress = new Uri("http://tanathos-001-site1.dtempurl.com/api/");
                    var responseTask = client.GetAsync("HojaClinica?valor="+textoBuscar);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<HojaClinicaModelView>>();
                        responseTask.Wait();
                        lstHojaClinica = readTask.Result;
                    }else
                    {
                        lstHojaClinica = Enumerable.Empty<HojaClinicaModelView>();
                        ModelState.AddModelError(string.Empty, "Ha ocurrido un error al obtener el modelo de datos");
                    }

                }
            }
                return View(lstHojaClinica);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HojaAndFarmacoModels hoja)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathos-001-site1.dtempurl.com/HojaClinica");
                var postTask = client.PostAsJsonAsync<HojaClinicaModelView>("HojaClinica",hoja.hojas);
                postTask.Wait();
                var resul = postTask.Result;
                if (resul.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Se ha registrado una hoja de forma exitosa";
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. contacta con el administrador");
            TempData["Error"] = "Ha Ocurrido un error al intentar guardar ";
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            HojaClinicaModelView hoja = null;
            HojaAndFarmacoModels valor = new HojaAndFarmacoModels();
            FarmacoHojaModelView farmaco = new FarmacoHojaModelView();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathos-001-site1.dtempurl.com/api/");
                var responseTask = client.GetAsync("HojaClinica?id=" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<HojaClinicaModelView>();
                    readTask.Wait();
                    hoja  = readTask.Result;
                    valor.hojas = new HojaClinicaModelView()
                    {
                        id = id,
                        lugar = hoja.lugar.ToString(),
                        fecha = hoja.fecha.ToString(),
                        antecedentes = hoja.antecedentes.ToString(),
                        diagnostico = hoja.diagnostico.ToString(),
                        tratamiento = hoja.tratamiento.ToString(),
                        observaciones = hoja.observaciones.ToString(),
                        fechaAlta = hoja.fechaAlta.ToString(),
                        marcaje = hoja.marcaje.ToString(),
                        idVeterinario = Convert.ToInt32(hoja.idVeterinario)
                    };
                }
            }

            
            return View(valor);
        }

        [HttpPost]
        public ActionResult Edit(HojaAndFarmacoModels hoja)
        {
           
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathos-001-site1.dtempurl.com/api/HojaClinica");
                var putTask = client.PutAsJsonAsync<HojaClinicaModelView>("HojaClinica",hoja.hojas);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Se ha editado una hoja de forma exitosa";
                    return RedirectToAction("Index");
                }
            }

            TempData["Error"] = "Ha Ocurrido un error al intentar actualizar ";
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult EditarFarmaco(string idClinica, string idFarmaco, string dosis, string frecuencia, string fechaAplicacion) {
            FarmacoHojaModelView farmaco = new FarmacoHojaModelView()
            {
                idClinica = Convert.ToInt32(idClinica),
                idFarmaco = Convert.ToInt32(idFarmaco),
                dosis = dosis,
                frecuencia = frecuencia,
                fechaAplicacion = fechaAplicacion
            };
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathos-001-site1.dtempurl.com/api/HojaFarmaco");
                var putTask = client.PutAsJsonAsync<FarmacoHojaModelView>("HojaFarmaco", farmaco);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    TempData["Success"] = "Se ha editado una hoja de forma exitosa";
                    return View();
                }
            }
            TempData["Error"] = "Ha Ocurrido un error al intentar actualizar ";
            return View();
        }
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://tanathos-001-site1.dtempurl.com/api/");
                var deleteTask = client.DeleteAsync("HojaClinica/"+id.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Se ha eliminado una hoja de forma exitosa";
                    return RedirectToAction("Index");
                }

            }

            TempData["Error"] = "Ha ocurrido un error al eliminar";
            return RedirectToAction("Index");
        }

    }
}