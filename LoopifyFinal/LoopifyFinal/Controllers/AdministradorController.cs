using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Loopify.Controllers
{
    public class AdministradorController : Controller
    {
        public ActionResult Panel()
        {

            ViewBag.Vendedores = new List<string> { "Vendedor1", "Vendedor2", "Vendedor3" };
            return View();
        }

        [HttpPost]
        public ActionResult CrearVendedor(string nombreVendedor)
        {
      
            ViewBag.Mensaje = $"¡Cuenta del vendedor '{nombreVendedor}' creada con éxito!";
            return RedirectToAction("Panel");
        }
    }
}
