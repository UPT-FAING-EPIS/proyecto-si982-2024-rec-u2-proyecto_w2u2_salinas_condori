using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Loopify.Controllers
{
    public class CuentaController : Controller
    {
      
        public ActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IniciarSesion(string usuario, string contrasena)
        {

            if (usuario == "admin" && contrasena == "admin123")
                return RedirectToAction("Panel", "Administrador");
            else if (usuario == "vendedor" && contrasena == "vendedor123")
                return RedirectToAction("Panel", "Vendedor");
            else if (usuario == "cliente" && contrasena == "cliente123")
                return RedirectToAction("Inicio", "Cliente"); 

           
            ViewBag.Error = "Usuario o contraseña incorrectos.";
            return View();
        }

        public ActionResult CerrarSesion()
        {
            Session.Clear();
            return RedirectToAction("IniciarSesion");
        }
    }
}
