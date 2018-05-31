using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaVentas.Models
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string  telefono { get; set; }
        public string web { get; set; }
    }
}