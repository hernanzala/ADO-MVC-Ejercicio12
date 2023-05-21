using ADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADO.Controllers
{
    public class HomeController : Controller 
    {
        public ActionResult Index()
        {
            AdmArticulo objAdm = new AdmArticulo(); 
            return View(objAdm.TraerTodos());
        }
        public ActionResult Alta()
        {
            return View();
        }
        public ActionResult Baja( int pCodigo)
        {
            AdmArticulo objAdm = new AdmArticulo();
            objAdm.Borrar(pCodigo);
            return RedirectToAction("Index");

        }
        public ActionResult Modificacion (int pCodigo)
        {
            AdmArticulo objadm = new AdmArticulo();
            Articulo articulo = objadm.TraerArticulo(pCodigo);
            return View(articulo);  
        }

        [HttpPost]
        public ActionResult Alta(FormCollection coleccion)
        {
            AdmArticulo objAdm = new AdmArticulo();
            Articulo articulo = new Articulo
            {
                Codigo = int.Parse(coleccion["codigo"]),
                Descripcion = coleccion["descripcion"],
                Precio = float.Parse(coleccion["precio"].ToString()),
            };

            objAdm.Alta(articulo);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Modificacion(FormCollection coleccion)
        {
            AdmArticulo objAdm = new AdmArticulo();
            Articulo articulo = new Articulo
            {
                Codigo = int.Parse(coleccion["codigo"].ToString()),
                Descripcion = coleccion["descripcion"].ToString(),
                Precio = float.Parse(coleccion["precio"].ToString()),
            };

            objAdm.ModificarArticulo(articulo);
            return RedirectToAction("Index");

        }

    }
}
        
        
        
       
        
        
