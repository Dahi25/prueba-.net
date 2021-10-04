namespace ConexionDB
{
    public class DBConexion
    {
        //conexion a la Base de datos Compurent y Ecomerce 
        public string GetConexion(string demoDB = "")
        {
            string cadena = string.Empty;
            string database = "PRUEBA";
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



