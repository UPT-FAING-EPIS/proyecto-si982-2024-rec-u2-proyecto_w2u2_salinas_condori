using System.Collections.Generic;

namespace Loopify.Models
{
    public class Producto
    {
        public string Nombre { get; set; }
        public double PrecioOriginal { get; set; }
        public double PrecioDescuento { get; set; }
        public string Imagen { get; set; }
    }

    public class Negocio
    {
        public string Nombre { get; set; }
        public List<Producto> Productos { get; set; }
    }
}
