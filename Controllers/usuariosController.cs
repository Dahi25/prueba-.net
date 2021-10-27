using PruebaDahiana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaDahiana.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registro()
        {
            var User = new Usuario();
            return View(User);
        }
    }
}

using System;
using System.Data.SqlClient;
using System.Web.Mvc;
using ConexionDB;
using PruebaDahiana.Models;

namespace PruebaDahiana.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        private static DBConexion DBConexion = new DBConexion();
        private static Usuario user = new Usuario(); //para usar el objecto en varias vistas
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Registro()
        {
            var user = new Usuario();



            return View(user);

        }
        public JsonResult RegistrarDatos(Usuario objUsuario) /* llamamos el metodo donde estamos guardando los datos*/
        {

            var resultado = false;

            resultado = RegistrarUsuarios(objUsuario);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public bool RegistrarUsuarios(Usuario user)
        {
            bool result = false;


            try
            {

                using (SqlConnection conexion = new SqlConnection(DBConexion.GetConexion()))
                
                {
                    conexion.Open();
            

        var INSERT = @"INSERT INTO datos (Cedula,Nombre,Cargo,Empresa,licenciamiento,azure,renting,Opcion) VALUES(@pCedula,@pNombre,@pCargo,@pEmpresa,@plicenciamiento,@pazure,@prenting,@pOpcion)";

                    using (SqlCommand comando = new SqlCommand(INSERT, conexion))
                    {
                        comando.Parameters.AddWithValue("@pCedula", user.Cedula);
                        comando.Parameters.AddWithValue("@pNombre", user.Nombre);
                        comando.Parameters.AddWithValue("@pCargo", user.Cargo);
                        comando.Parameters.AddWithValue("@pEmpresa", user.Empresa);
                        comando.Parameters.AddWithValue("@plicenciamiento", user.licenciamiento);
                        comando.Parameters.AddWithValue("@pazure", user.azure);
                        comando.Parameters.AddWithValue("@prenting", user.renting);
                        comando.Parameters.AddWithValue("@pOpcion", user.Opcion);
                        comando.ExecuteNonQuery();
                    }


                    result = true;
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }
        public JsonResult ActualizarDatos(Usuario objUsuario) /* llamamos el metodo donde estamos guardando los datos*/
        {

            var respuesta = false;

            respuesta = ActualizarUsuarios(objUsuario);
            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }

        /* Metodo para actualizar datos */
        public bool ActualizarUsuarios(Usuario user)
        {
            bool result = false;

            try
            {

                using (SqlConnection conexion = new SqlConnection(DBConexion.GetConexion()))
                {
                    conexion.Open();
                    var UPDATE = @"UPDATE datos SET Nombre = @pNombre, Cargo=@pCargo, Empresa=@pEmpresa,licenciamiento=@licenciamiento,azure=@pazure,renting=@prenting,Opcion=@Opcion where Cedula = @pCedula";






                    using (SqlCommand comando = new SqlCommand(UPDATE, conexion))
                    {
                        comando.Parameters.AddWithValue("@pCedula", user.Cedula);
                        comando.Parameters.AddWithValue("@pNombre", user.Nombre);
                        comando.Parameters.AddWithValue("@pCargo", user.Cargo);
                        comando.Parameters.AddWithValue("@pEmpresa", user.Empresa);
                        comando.Parameters.AddWithValue("@plicenciamiento", user.licenciamiento);
                        comando.Parameters.AddWithValue("@pazure", user.azure);
                        comando.Parameters.AddWithValue("@prenting", user.renting);
                        comando.ExecuteNonQuery();

                    }


                    result = true;
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }
        public JsonResult EliminarDatos(Usuario objUsuario) /* llamamos el metodo donde estamos guardando los datos*/
        {

            var respuesta = false;

            respuesta = EliminarUsuarios(objUsuario);
            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }

        /* Metodo para Eliminar datos */
        public bool EliminarUsuarios(Usuario user)
        {
            bool result = false;

            try
            {

                using (SqlConnection conexion = new SqlConnection(DBConexion.GetConexion()))
                {
                    conexion.Open();
                    var DElETE = @"DElETE from datos  where Cedula = @pCedula";






                    using (SqlCommand comando = new SqlCommand(DElETE, conexion))
                    {
                        comando.Parameters.AddWithValue("@pCedula", user.Cedula);
                        comando.ExecuteNonQuery();

                    }


                    result = true;
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }
        public ActionResult Garantía()
        {
            var user = new Usuario();



            return View(user);

        }
        public JsonResult EnviarSolicitud(Usuario objUsuario) /* llamamos el metodo donde estamos guardando los datos*/
        {

            var respuestaone = false;

            respuestaone = EnviarUsuarios(objUsuario);
            return Json(respuestaone, JsonRequestBehavior.AllowGet);
        }


        public bool EnviarUsuarios(Usuario user)
        {
            bool result = false;

            try
            {

                using (SqlConnection conexion = new SqlConnection(DBConexion.GetConexion()))
                {
                    conexion.Open();

                    var INSERT = @"INSERT INTO garantias (Cedula,Falla,licenciamiento,azure,renting) VALUES(@pCedula,@pFalla,@plicenciamiento,@pazure,@prenting)";

                    using (SqlCommand comando = new SqlCommand(INSERT, conexion))
                    {
                        comando.Parameters.AddWithValue("@pCedula", user.Cedula);
                        comando.Parameters.AddWithValue("@pFalla", user.Falla);
                        comando.Parameters.AddWithValue("@plicenciamiento", user.licenciamiento);
                        comando.Parameters.AddWithValue("@pazure", user.azure);
                        comando.Parameters.AddWithValue("@prenting", user.renting);
                        comando.ExecuteNonQuery();
                    }


                    result = true;
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }
    }
    
  }
