using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Loopify.Controllers
{
    public class VendedorController : Controller
    {
        public ActionResult Panel()
        {
            ViewBag.Negocio = new
            {
                Nombre = "Panadería Dulce Vida",
                Productos = new List<dynamic> {
                    new { Nombre = "Pan Integral", Precio = 6.00, Descuento = 0.25 },
                    new { Nombre = "Rosquillas", Precio = 8.00, Descuento = 0.30 }
                }
            };

            return View();
        }

        [HttpPost]
        public ActionResult AgregarProducto(string nombre, double precio, double descuento)
        {
       
            ViewBag.Mensaje = $"¡Producto '{nombre}' agregado con éxito!";
            return RedirectToAction("Panel");
        }
    }
}