using Loopify.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Loopify.Controllers
{
    public class ClienteController : Controller
    {
        public ActionResult Inicio()
        {
            var negocios = new List<Negocio>
            {
                new Negocio
                {
                    Nombre = "Panadería Dulce Vida",
                    Productos = new List<Producto>
                    {
                        new Producto
                        {
                            Nombre = "Pan Integral",
                            PrecioOriginal = 6.00,
                            PrecioDescuento = 4.50,
                            Imagen = "panintegral.png"
                        },
                        new Producto
                        {
                            Nombre = "Rosquillas",
                            PrecioOriginal = 8.00,
                            PrecioDescuento = 5.50,
                            Imagen = "rosquillas.jpg"
                        }
                    }
                },
                new Negocio
                {
                    Nombre = "Lácteos Frescos",
                    Productos = new List<Producto>
                    {
                        new Producto
                        {
                            Nombre = "Leche Entera",
                            PrecioOriginal = 3.50,
                            PrecioDescuento = 2.90,
                            Imagen = "lecheentera.jpg"
                        },
                        new Producto
                        {
                            Nombre = "Yogurt Natural",
                            PrecioOriginal = 5.00,
                            PrecioDescuento = 4.20,
                            Imagen = "yogurtnatural.jpg"
                        }
                    }
                }
            };

            return View(negocios);
        }
    }
}
