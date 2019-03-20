﻿using System.Web;
using System.Web.Optimization;

namespace Fadiou
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération à l'adresse https://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/asset/dist/js/adminlte.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/asset/bower_components/bootstrap/dist/css/bootstrap.css",
                      "~/asset/bower_components/font-awesome/css/font-awesome.min.css",
                      "~/asset/bower_components/Ionicons/css/ionicons.min.css",
                      "~/asset/dist/css/AdminLTE.min.css",
                      "~/asset/dist/css/skins/skin-blue.min.css",
                      "~/content/PagedList.css"));

        }
    }
}
