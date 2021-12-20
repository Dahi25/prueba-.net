using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba.Models
{
    public class Usuario
    {
        public String Cedula { get; set; }
        public String Nombre { get; set; }
        public String Cargo { get; set; }
        public String Empresa { get; set; }
        public Boolean licenciamiento { get; set; }
        public Boolean azure { get; set; }
        public Boolean renting { get; set; }
        public String falla { get; set; }
        public bool Opcion { get; set; }
        public bool Solicitar { get; set; }

    }
}