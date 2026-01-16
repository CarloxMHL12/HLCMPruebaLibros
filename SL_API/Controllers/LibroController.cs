using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.UI.WebControls;


namespace SL_API.Controllers
{
    [RoutePrefix("api/Libro")]
    public class LibroController : ApiController
    {

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Libro libro = new ML.Libro();
            libro.Autor = new ML.Autor();
            libro.Editorial = new ML.Editorial();
            libro.Autor.Nombre = "";
            libro.Titulo = "";
            libro.AnioPublicacion = 0;
            libro.Editorial.Nombre = "";

            ML.Result result = BL.Libro.GetAll(libro);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }

        }


        [HttpPost]
        [Route("Add")]
        public IHttpActionResult Add([FromBody] ML.Libro libro)
        {
            ML.Result result = BL.Libro.Add(libro);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }


        [HttpDelete]
        [Route("LibroDeleteAutor/{idAutor}")]
        public IHttpActionResult LibroDeleteAutor(int idAutor)
        {
            ML.Result result = BL.Libro.LibroDeleteAutor(idAutor);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }



        [HttpDelete]
        [Route("LibroDeleteEditorial/{idEditorial}")]
        public IHttpActionResult LibroDeleteEditorial(int idEditorial)
        {
            ML.Result result = BL.Libro.LibroDeleteEditorial(idEditorial);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }



        [HttpPost]
        [Route("Busqueda")]
        public IHttpActionResult Busqueda([FromBody] ML.Libro usuarioBusqueda)
        {
            if (usuarioBusqueda == null)
            {
                usuarioBusqueda = new ML.Libro();
            }

            if (usuarioBusqueda.Autor == null)
            {
                usuarioBusqueda.Autor = new ML.Autor();
            }

            if (usuarioBusqueda.Editorial == null)
            {
                usuarioBusqueda.Editorial = new ML.Editorial();
            }

            ML.Result result = BL.Libro.GetAll(usuarioBusqueda);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }


    }
}