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




    }
}