using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ConsultaARSHospital
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DoctoresCreate",
                url: "Doctores/Create",
                defaults: new { controller = "Doctores", action = "Create" }
            );

            routes.MapRoute(
                name: "HospitalesIndex",
                url: "Hospitales/IndexHospitales",
                defaults: new { controller = "Hospitales", action = "IndexHospitales" }
            );

            routes.MapRoute(
                name: "IndexDoctores",
                url: "Doctores/IndexDoctores/{idHospital}",
                defaults: new { controller = "Doctores", action = "IndexDoctores" }

                );
            routes.MapRoute(
              name: "EspecialidadesPorDoctor",
              url: "Doctores/{idDoctor}/Especialidades",
              defaults: new { controller = "Especialidades", action = "IndexEspecialidades" }
                );

            routes.MapRoute(
              name: "About",
              url: "Home/About",
              defaults: new { controller = "Home", action = "About" }
                );


            routes.MapRoute(
                name: "EditarDoctor",
                url: "Home/EditarDoctor/{id}",
                defaults: new { controller = "Home", action = "EditarDoctor", id = UrlParameter.Optional }
            );
        }
    }
}
