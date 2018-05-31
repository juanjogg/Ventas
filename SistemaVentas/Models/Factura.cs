using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaVentas.Models
{
    public class Factura
    {
        public Ventas venta { get; set; }
        public Producto producto { get; set; }
        public int cantidad { get; set; }
    }
}