﻿using System.Web;
using System.Web.Optimization;

namespace CiZoochilpan
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
          

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/datetime").Include(
              "~/Scripts/moment*",
              "~/Scripts/bootstrap-datetimepicker*"));

            bundles.Add(new ScriptBundle("~/bundles/apis").Include(
                      "~/Scripts/scriptApi.js"));

            bundles.Add(new ScriptBundle("~/bundles/orden").Include(
                      "~/Scripts/CargarOrdenes.js"));

            bundles.Add(new ScriptBundle("~/bundles/animal").Include(
                      "~/Scripts/AnimalScript.js"));

            bundles.Add(new ScriptBundle("~/bundles/editAnimal").Include(
                     "~/Scripts/EditarAnimal.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-datetimepicker.css",
                      "~/Content/miEstilo.css",
                      "~/Content/site.css"));

           // bundles.Add(new StyleBundle("~/Content/css").Include(
             //   "~/Content/miEstilo.css"));
        }
    }
}
