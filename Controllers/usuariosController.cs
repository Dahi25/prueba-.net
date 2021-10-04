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