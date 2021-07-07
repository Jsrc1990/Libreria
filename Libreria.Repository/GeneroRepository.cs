using System;
using System.Collections.Generic;
using System.Linq;
using TransversalLibrary;

namespace Libreria.Repository
{
    public class GeneroRepository
    {
        private readonly Entities entities;

        public GeneroRepository()
        {
            entities = new Entities();
        }

        public Response<IEnumerable<GENERO>> Consultar(string valor = "")
        {
            try
            {
                List<GENERO> Generos = null;
                if (string.IsNullOrWhiteSpace(valor))
                    Generos = entities?.GENERO?.ToList();
                else
                    Generos = entities?.GENERO?.Where(x => x.ID == valor)?.ToList();
                return new Response<IEnumerable<GENERO>>()
                {
                    Data = Generos
                };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<GENERO>>()
                {
                    Data = new List<GENERO>(),
                    Exception = ex,
                    HttpStatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }

        public Response<GENERO> Insertar(GENERO Genero)
        {
            try
            {
                if (entities?.GENERO?.Any(x => x.ID == Genero.ID) == false)
                {
                    Genero.ID = Guid.NewGuid().ToString().Replace("-", string.Empty);
                    entities?.GENERO?.Add(Genero);
                    entities?.SaveChanges();
                }
                return new Response<GENERO>()
                {
                    Data = Genero
                };
            }
            catch (Exception ex)
            {
                return new Response<GENERO>()
                {
                    Data = null,
                    Exception = ex,
                    HttpStatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }

        public Response<bool> Editar(GENERO Genero)
        {
            try
            {
                GENERO first = entities?.GENERO?.FirstOrDefault(x => x.ID == Genero.ID);
                if (first != null)
                {
                    first.NOMBRE = Genero?.NOMBRE;
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

        public Response<bool> Eliminar(GENERO Genero)
        {
            try
            {
                GENERO first = entities?.GENERO?.FirstOrDefault(x => x.ID == Genero.ID);
                if (first != null)
                {
                    entities?.GENERO?.Remove(first);
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