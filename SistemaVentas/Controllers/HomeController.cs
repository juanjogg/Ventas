﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DT = SistemaVentas.Data;
using MD = SistemaVentas.Models;

namespace SistemaVentas.Controllers
{
    public class HomeController : Controller
    {
        DT.ServerVentasEntities dataBase = new DT.ServerVentasEntities();
        public ActionResult Index()
        {
            List<MD.Producto> productos = consultarProductos();
            return View(productos);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public List<MD.Producto> consultarProductos()
        {
            List<MD.Producto> productos = new List<MD.Producto>();
            var item = from p in dataBase.Productos
                       where (p.Stock > 0)
                       select new { p.IdCategoria,p.Nombre,p.Precio};
            foreach (var prod in item)
            {
                if(prod.Nombre == null)
                {
                    return null;
                }
                else
                {
                    MD.Producto producto = new MD.Producto();
                    producto.IdCategoria = prod.IdCategoria;
                    producto.nombre = prod.Nombre;
                    producto.precio = prod.Precio;
                    productos.Add(producto);
                }
            }

            return productos;
        }
    }
}