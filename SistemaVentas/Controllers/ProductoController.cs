using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MD = SistemaVentas.Models;
using DT = SistemaVentas.Data;

namespace SistemaVentas.Controllers
{

    public class ProductoController : Controller
    {
        
        DT.ServerVentasEntities dataBase = new DT.ServerVentasEntities();        
        // GET: Producto
        public ActionResult Ver(int id)
        {
            MD.Producto producto = new MD.Producto();
            producto = consultarProducto(id);
            ViewBag.listado = obtenerStock(producto.stock);
            ViewBag.id = id;
            return View(producto);
        }

        [HttpPost]
        public ActionResult ShoppingCart(MD.Producto producto)
        {
            if (Session["userID"] != null)
            {


                

                Shitems.shProducto.Add(producto);
                return View(Shitems.shProducto);
            }
            else
            {
                return RedirectToAction("Index", "Cuenta");
            }
            
        }
        
        public ActionResult Compra()
        {
            double d = calcularTotal();
            agregarVenta(d);
            return RedirectToAction("Index","Home");
        }

        public MD.Producto consultarProducto(int id)
        {
            var prod = from p in dataBase.Productos
                       where (p.Id == id)
                       select new { p.Precio, p.Nombre,p.Categoria,p.Id, p.Stock, p.Descripcion};
            MD.Producto producto = new MD.Producto();
            foreach(var pd in prod)
            {
                producto.Id = pd.Id;
                producto.precio = pd.Precio;
                producto.nombre = pd.Nombre;
                producto.stock = pd.Stock;
                producto.descripcion = pd.Descripcion;
                producto.categoria = new MD.Categoria();
                producto.categoria.descripcion = pd.Categoria.Descripcion;
                
            }     
            return producto;
        }
        public List<SelectListItem> obtenerStock(int stock)
        {
            
            List<SelectListItem> items = new List<SelectListItem>();
            for (int i = 0; i < stock; i++)
            {
                SelectListItem item = new SelectListItem();
                item.Text = (i + 1).ToString();
                item.Value = (i + 1).ToString();
                items.Add(item);
            }

            
            return items;
        }

        public void agregarVenta(double total)
        {
            int numero = dataBase.Ventas.Count();
            try
            {
                DT.Venta venta = new DT.Venta();
                venta.Id = numero + 1;
                venta.IdCliente = CuentaController.clientec.Id;
                venta.Descuento = 0;
                venta.Fecha = DateTime.Now.Date;
                venta.Total = total;
                dataBase.Ventas.Add(venta);
                dataBase.SaveChanges();
                agregarFactura(venta.Id);
                
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public void agregarFactura(int idVenta)
        {
            try
            {
                foreach (MD.Producto producto in Shitems.shProducto)
                {
                    DT.Factura factura = new DT.Factura();

                    //factura.Producto = new DT.Producto();
                    //factura.Producto.Descripcion = producto.descripcion;
                    //factura.Producto.Id = producto.Id;
                    //factura.Producto.Nombre = producto.nombre;
                    //factura.Producto.Precio = producto.precio;
                    factura.IdProducto = producto.Id;
                    factura.IdVenta = idVenta;
                    factura.Cantidad = producto.cantidad;
                    dataBase.Facturas.Add(factura);
                    dataBase.SaveChanges();

                }
                Shitems.shProducto.Clear();
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }
        public double calcularTotal()
        {
            double total = 0;
            foreach(MD.Producto prod in Shitems.shProducto)
            {
                total += prod.precio * prod.cantidad;
            }
            return total;
        }
    }
    internal class Shitems
    {
        internal static List<MD.Producto> shProducto = new List<MD.Producto>();
    }
}