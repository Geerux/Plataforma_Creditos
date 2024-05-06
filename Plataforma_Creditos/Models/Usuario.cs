using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plataforma_Creditos.Models
{
    public class Usuario
    {

        public int Id { get; set; } 
        public string Name { get; set; }
        public string Apellido_Materno { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Password { get; set; }    
        // Aqui se ponen las columnas de las tablas en la base de datos

        public string ConfirmarClave { get; set; }
    }
}