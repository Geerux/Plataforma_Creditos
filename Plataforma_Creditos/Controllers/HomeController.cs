using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plataforma_Creditos.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult MiPagina()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Login()
        {
            ViewBag.Message = "asgasg";

            return View();
        }

        public ActionResult Carreras()
        {
            ViewBag.Message = "asgasg";

            return View();
        }
        public ActionResult Actividades()
        {
            ViewBag.Message = "asgasg";

            return View();
        }

        public ActionResult alumnos()
        {
            ViewBag.Message = "asgasg";

            return View();
        }


        public ActionResult CerrarSesion()
        {
            Session["IdAlumno"] = null;
            return RedirectToAction("Login", "Acceso");
        }



    }
}