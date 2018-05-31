using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaVentas.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string  direccion { get; set; }
    }
}