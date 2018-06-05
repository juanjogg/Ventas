﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MD = SistemaVentas.Models;
using DT = SistemaVentas.Data;

namespace SistemaVentas.Controllers
{
    public class CuentaController : Controller
    {
        // GET: Cuenta
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ingreso(MD.Cliente cliente)
        {
            DT.ServerVentasEntities dataBase = new DT.ServerVentasEntities();
            var user = dataBase.Clientes.Where(x => x.Id == cliente.Id).FirstOrDefault();
            if (user == null)
            {
                cliente.errorLogin = "ID incorrecto!";
                return View("Index", cliente);
            }
            else
            {
                Session["userID"] = user.Id;
                ViewBag.nombre = user.Nombre;
                return RedirectToAction("Index","Home");
            }
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }
    }
       
  
    
}