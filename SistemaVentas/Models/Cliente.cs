using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SistemaVentas.Models
{
    public class Cliente
    {
        [DisplayName("Id Usuario")]
        public int Id { get; set; }
        
        public string nombre { get; set; }
        public string  direccion { get; set; }
        public string errorLogin { get; set; }
    }
}