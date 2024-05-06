using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plataforma_Creditos.Models
{
    public class RegistroDeCreditos
    {

        public int Folio { get; set; }
        public DateTime DateTime { get; set; }
        public string Alumno { get; set; }
        public string TipoDeCredito { get; set; }
        public int Cantidad { get; set; }
        public string Descripicion { get; set; }



    }
}