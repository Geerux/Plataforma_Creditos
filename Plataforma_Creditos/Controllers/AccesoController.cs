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

        static string con = @"Data Source = GEERUX\SQLEXPRESS2014; Initial Catalog = Creditos; User = sa; Password = 21030203";

        public static string Key = "";
        public static string Resultado = "";
        public readonly Encoding Encoder = Encoding.UTF8;
        // Acceso Login 

       

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
            Usuario Alumno = new Usuario();
            if (Alumno.Contraseña == Alumno.ConfirmarClave)
            {
                // Aplicar metodo de encriptacion
                return View();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "La contraseña no es la misma");
                return View(); //Retornar vista de login
            }


            using (SqlConnection cn = new SqlConnection(con))
            {

                SqlCommand cmd = new SqlCommand("SP_RegistrarAlumno", cn);
                cmd.Parameters.AddWithValue("Id", Alumno.Id);
                cmd.Parameters.AddWithValue("Matricula", Alumno.Matricula);
                cmd.Parameters.AddWithValue("Nombre",Alumno.Nombre);
                cmd.Parameters.AddWithValue("ApellidoPaterno", Alumno.Apellido_Paterno);
                cmd.Parameters.AddWithValue("ApellidoMaterno", Alumno.Apellido_Materno);

                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                cmd.ExecuteNonQuery();

                //Mostrar mensaje de que el usuario se registro con exito 

            }

            string Contraseña2 = "";
            Contraseña2 = encriptar(Contraseña);

            SqlParameter[] parameters =
            {
                new SqlParameter("@Usuario", SqlDbType.VarChar) {Value = Usuario},
                new SqlParameter("@Contraseña", SqlDbType.VarChar) {Value = Contraseña2}
            };
            

            return View(); // Redirigir a Login

        }

  
        




        [HttpPost]
        public ActionResult Login(Usuario Alumno)
        {
           
            using (SqlConnection cn = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand("SP_ValidarAlumno", cn);
                cmd.Parameters.AddWithValue("Nombre", Alumno.Nombre);
                cmd.Parameters.AddWithValue("Contraseña", Alumno.Contraseña);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                Alumno.Id = Convert.ToInt32(cmd.ExecuteScalar().ToString());

            }

            if (Alumno.Id != 0)
            {
                Session["usuario"] = Alumno;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //Mensaje para indicar que el usuario no existe
                return View();
            }
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




        //// Metodos de encriptacion
        ///Es el de Triple DES
        static TripleDES CrearDES(string Key)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            TripleDES des = new TripleDESCryptoServiceProvider();
            var desKey = md5.ComputeHash(Encoding.UTF8.GetBytes(Key));
            des.Key = desKey;
            des.IV = new byte[des.BlockSize / 8];
            des.Padding = PaddingMode.PKCS7;
            des.Mode = CipherMode.ECB;
            return des;
        }

        static string encriptar(string textoplano)
        {
            var des = CrearDES(Key);
            var ct = des.CreateEncryptor();
            var entrada = Encoding.UTF8.GetBytes(textoplano);
            var salida = ct.TransformFinalBlock(entrada, 0, entrada.Length);
            return Convert.ToBase64String(salida);
        }

        static string desencriptar(string textocifrado)
        {
            var des = CrearDES(Key);
            var ct = des.CreateDecryptor();
            var entrada = Convert.FromBase64String(textocifrado);
            var salida = ct.TransformFinalBlock(entrada, 0, entrada.Length);
            return Encoding.UTF8.GetString(salida);
        }
    }
}
