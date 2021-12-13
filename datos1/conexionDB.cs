using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace conexionDB
{
    public class conexionDB1
    {
        //Conexión a la Base de datos Compurent y eCommerce 
        public string GetConexion(string demoDB = "")
        {
            string cadena = string.Empty;
            string database = "USUARIO";
            if (!string.IsNullOrWhiteSpace(demoDB))
            {
                database = demoDB;
            }

            try
            {
                cadena = @"Server=CRMV-FRONTDBOLD\DEMO; User id=sa; Password=ofima.sql10; multipleactiveresultsets=True; timeout=0; Initial Catalog=" + database;
            }
            catch
            {
            }
            return cadena;
        }
    }
}
