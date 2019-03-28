using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using CiZoochilpan.Areas.Medicina.Models;

namespace CiZoochilpan.Areas.Medicina.Controllers
{
    public class UserController : Controller
    {
        // GET: Medicina/User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string nombre, string email)
        {
            UserModelView usuario = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://zoochilpan.azurewebsites.net/api/");
                var responseTask = client.GetAsync("User?email="+email+"&nombre="+nombre);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UserModelView>();
                    readTask.Wait();
                    usuario = readTask.Result;
                    Session["nombreUsuario"] = usuario.nombre.ToString();
                    Session["email"] = usuario.email.ToString();

                }
            }

            return RedirectToAction("Index","Home");
        }

    }
}