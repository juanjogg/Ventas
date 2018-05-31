using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaVentas.Models
{
    public class Ventas
    {
        public int IdVenta { get; set; }
        public DateTime fecha { get; set; }
        public int IdCliente { get; set;}
        public double descuento { get; set; }
        public double total { get; set; }

    }
}