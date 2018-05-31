﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaVentas.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }
        public int stock { get; set; }
        public int IdProveedor { get; set; }
        public int IdCategoria { get; set; }
    }
}