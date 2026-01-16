using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

            libro.Titulo = "";
            libro.Autor = new ML.Autor();
            libro.Editorial = new ML.Editorial();


            ML.Result resultLibros = GetAllREST();

            if (resultLibros.Correct && resultLibros.Objects != null)
            {
                libro.Libros = resultLibros.Objects;
            }
            else
            {
                libro.Libros = new List<object>();
            }

            return View(libro);
        }


        [HttpPost]
        public ActionResult GetAll(ML.Libro libroBusqueda)
        {
         
            if (libroBusqueda == null)
            {
                libroBusqueda = new ML.Libro();
            }

            if (libroBusqueda.Autor == null)
            {
                libroBusqueda.Autor = new ML.Autor();
            }

            if (libroBusqueda.Editorial == null)
            {
                libroBusqueda.Editorial = new ML.Editorial();
            }

     
            libroBusqueda.Titulo = libroBusqueda.Titulo ?? "";
            libroBusqueda.Autor.Nombre = libroBusqueda.Autor.Nombre ?? "";

            ML.Result resultLibros = BusquedaREST(libroBusqueda);

            if (resultLibros.Correct && resultLibros.Objects != null)
            {
                libroBusqueda.Libros = resultLibros.Objects;
            }
            else
            {
                libroBusqueda.Libros = new List<object>();
            }

            return View(libroBusqueda);
        }











        [NonAction]
        public static ML.Result GetAllREST()
        {
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:55963/api/Libro/");

                    var responseTask = client.GetAsync("GetAll");
                    responseTask.Wait();

                    var response = responseTask.Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        ML.Result resultAPI = readTask.Result;

                        if (resultAPI.Correct && resultAPI.Objects != null)
                        {
                            foreach (var item in resultAPI.Objects)
                            {
                                ML.Libro libro =
                                    Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Libro>(item.ToString());

                                result.Objects.Add(libro);
                            }

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "La API no regresó libros";
                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = response.ReasonPhrase;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }


        [NonAction]
        public static ML.Result BusquedaREST(ML.Libro libroBusqueda)
        {
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:55963/api/Libro/");

                    var responseTask = client.PostAsJsonAsync("Busqueda", libroBusqueda);
                    responseTask.Wait();

                    var response = responseTask.Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        ML.Result resultAPI = readTask.Result;

                        if (resultAPI.Correct && resultAPI.Objects != null)
                        {
                            foreach (var item in resultAPI.Objects)
                            {
                                ML.Libro libro =
                                    Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Libro>(item.ToString());

                                result.Objects.Add(libro);
                            }

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "La API no regresó libros";
                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = response.ReasonPhrase;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }




    }
}