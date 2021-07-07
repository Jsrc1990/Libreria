using System;
using System.Collections.Generic;
using System.Linq;
using TransversalLibrary;

namespace Libreria.Repository
{
    public class CiudadRepository
    {
        private readonly Entities entities;

        public CiudadRepository()
        {
            entities = new Entities();
        }

        public Response<IEnumerable<CIUDAD>> Consultar(string valor = "")
        {
            try
            {
                List<CIUDAD> Ciudads = null;
                if (string.IsNullOrWhiteSpace(valor))
                    Ciudads = entities?.CIUDAD?.ToList();
                else
                    Ciudads = entities?.CIUDAD?.Where(x => x.ID == valor)?.ToList();
                return new Response<IEnumerable<CIUDAD>>()
                {
                    Data = Ciudads
                };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<CIUDAD>>()
                {
                    Data = new List<CIUDAD>(),
                    Exception = ex,
                    HttpStatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }

        public Response<CIUDAD> Insertar(CIUDAD Ciudad)
        {
            try
            {
                if (entities?.CIUDAD?.Any(x => x.ID == Ciudad.ID) == false)
                {
                    Ciudad.ID = Guid.NewGuid().ToString().Replace("-", string.Empty);
                    entities?.CIUDAD?.Add(Ciudad);
                    entities?.SaveChanges();
                }
                return new Response<CIUDAD>()
                {
                    Data = Ciudad
                };
            }
            catch (Exception ex)
            {
                return new Response<CIUDAD>()
                {
                    Data = null,
                    Exception = ex,
                    HttpStatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }

        public Response<bool> Editar(CIUDAD Ciudad)
        {
            try
            {
                CIUDAD first = entities?.CIUDAD?.FirstOrDefault(x => x.ID == Ciudad.ID);
                if (first != null)
                {
                    first.NOMBRE = Ciudad?.NOMBRE;
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

        public Response<bool> Eliminar(CIUDAD Ciudad)
        {
            try
            {
                CIUDAD first = entities?.CIUDAD?.FirstOrDefault(x => x.ID == Ciudad.ID);
                if (first != null)
                {
                    entities?.CIUDAD?.Remove(first);
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