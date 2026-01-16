using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class LibroController : Controller
    {

        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Libro libro = new ML.Libro();
            libro.Autor = new ML.Autor();
            libro.Editorial = new ML.Editorial();
            libro.Libros = new List<object>();

            return View(libro);
        }

        // POST - BÚSQUEDA
        [HttpPost]
        public ActionResult Index(ML.Libro libroBusqueda)
        {
          

          

            return View(libroBusqueda);
        }

        // GET Alta
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }
    }
}