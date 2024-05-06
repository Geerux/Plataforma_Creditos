using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plataforma_Creditos.Models;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace Plataforma_Creditos.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso

        static string Cadena = "DataSourceNoseQueMasWeassssss;" + "Initial Catalog = NombreBaseDeDatos; ";

        public ActionResult Login(Usuario Usuario)
        {
            //Usuario.Usr_Pass = 

            return View();
        }

        public ActionResult Registro()
        {
            return View();
        }



        //public static string ConvertirClave(string texto)
        //{
        //    //MetodoDeEcnriptacion
        //}

        [HttpPost]
        public ActionResult Registrar()
        {
            if (Usuario.Us_Contraseña == Usuario.Us_ConfirmarClave)
            {
                // Aplicar metodo de encriptacion

            }
            else
            {
                return ViewContext(); //Retornar vista de login
            }

            
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            //Usuario.Us_Contraseña = //Llamar el metodo de encriptacion
            //Aqui se pone el metodo para desencriptar



        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: Acceso/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Acceso/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Acceso/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Acceso/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Acceso/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Acceso/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Acceso/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
