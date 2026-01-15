using System;
using System.Net;
using System.Web.Http;


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




    }
}