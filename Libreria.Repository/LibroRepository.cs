using System;
using System.Collections.Generic;
using System.Linq;
using TransversalLibrary;

namespace Libreria.Repository
{
    public class LibroRepository
    {
        private readonly Entities entities;

        public LibroRepository()
        {
            entities = new Entities();
        }

        public Response<IEnumerable<LIBRO>> Consultar(string valor = "")
        {
            try
            {
                List<LIBRO> Libros = null;
                if (string.IsNullOrWhiteSpace(valor))
                    Libros = entities?.LIBRO?.Include(nameof(LIBRO.GENERO1))?.ToList();
                else
                    Libros = entities?.LIBRO?.Include(nameof(LIBRO.GENERO1))?.Where(x =>
                    x.ID == valor ||
                    x.AUTOR1.NOMBRECOMPLETO.ToLower().Contains(valor.ToLower()) ||
                    x.TITULO.ToLower().Contains(valor.ToLower())
                    )?.ToList();
                //Convert.ToInt32(x.AÑO).ToString() == valor
                return new Response<IEnumerable<LIBRO>>()
                {
                    Data = Libros
                };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<LIBRO>>()
                {
                    Data = new List<LIBRO>(),
                    Exception = ex,
                    HttpStatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }

        public Response<LIBRO> Insertar(LIBRO Libro)
        {
            try
            {
                if (entities?.LIBRO?.Any(x => x.ID == Libro.ID) == false)
                {
                    Libro.ID = Guid.NewGuid().ToString().Replace("-", string.Empty);
                    entities?.LIBRO?.Add(Libro);
                    entities?.SaveChanges();
                }
                return new Response<LIBRO>()
                {
                    Data = Libro
                };
            }
            catch (Exception ex)
            {
                return new Response<LIBRO>()
                {
                    Data = null,
                    Exception = ex,
                    HttpStatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }

        public Response<bool> Editar(LIBRO libro)
        {
            try
            {
                LIBRO first = entities?.LIBRO?.FirstOrDefault(x => x.ID == libro.ID);
                if (first != null)
                {
                    first.TITULO = libro?.TITULO;
                    first.AUTOR = libro?.AUTOR;
                    first.AÑO = libro.AÑO;
                    first.GENERO = libro?.GENERO;
                    first.NUMEROPAGINAS = libro.NUMEROPAGINAS;
                    entities?.SaveChanges();
                }
                return new Response<bool>()
                {
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new Response<bool>()
                {
                    Data = false,
                    Exception = ex,
                    HttpStatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }

        public Response<bool> Eliminar(LIBRO Libro)
        {
            try
            {
                LIBRO first = entities?.LIBRO?.FirstOrDefault(x => x.ID == Libro.ID);
                if (first != null)
                {
                    entities?.LIBRO?.Remove(first);
                    entities?.SaveChanges();
                }
                return new Response<bool>()
                {
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new Response<bool>()
                {
                    Data = false,
                    Exception = ex,
                    HttpStatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }
    }
}