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
    }
    internal class Shitems
    {
        internal static List<MD.Producto> shProducto = new List<MD.Producto>();
    }
}