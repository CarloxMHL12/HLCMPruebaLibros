using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libro
    {


        public static ML.Result GetAll(ML.Libro libroBusqueda)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.HLCMPruebaLibrosEntities context = new DL.HLCMPruebaLibrosEntities())
                {
                    var registros = context.LibroGetAll(libroBusqueda.Autor.Nombre, libroBusqueda.Titulo, libroBusqueda.AnioPublicacion, libroBusqueda.Editorial.Nombre).ToList();

                    if (registros != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var libros in registros)
                        {
                            ML.Libro libro = new ML.Libro();
                            libro.IdLibro = libros.IdLibro;
                            libro.Titulo = libros.Titulo;
                            libro.AnioPublicacion = libros.AnioPublicacion;

                            libro.Autor = new ML.Autor();
                            libro.Autor.Nombre = libros.NombreAutor;
                            libro.Autor.Apellidos = libros.Apellidos;

                            libro.Editorial = new ML.Editorial();
                            libro.Editorial.Nombre = libros.NombreEditorial;

                            result.Objects.Add(libro);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay Información que mostrar";
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
