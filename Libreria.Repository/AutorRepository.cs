using System;
using System.Collections.Generic;
using System.Linq;
using TransversalLibrary;

namespace Libreria.Repository
{
    public class AutorRepository
    {
        private readonly Entities entities;

        public AutorRepository()
        {
            entities = new Entities();
        }

        public Response<IEnumerable<AUTOR>> Consultar(string valor = "")
        {
            try
            {
                List<AUTOR> Autors = null;
                if (string.IsNullOrWhiteSpace(valor))
                    Autors = entities?.AUTOR?.Include(nameof(AUTOR.CIUDAD))?.ToList();
                else
                    Autors = entities?.AUTOR?.Include(nameof(AUTOR.CIUDAD))?.Where(x => x.ID == valor || x.NOMBRECOMPLETO.ToLower().Contains(valor.ToLower()))?.ToList();
                return new Response<IEnumerable<AUTOR>>()
                {
                    Data = Autors
                };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<AUTOR>>()
                {
                    Data = new List<AUTOR>(),
                    Exception = ex,
                    HttpStatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }

        public Response<AUTOR> Insertar(AUTOR Autor)
        {
            try
            {
                if (entities?.AUTOR?.Any(x => x.ID == Autor.ID) == false)
                {
                    Autor.ID = Guid.NewGuid().ToString().Replace("-", string.Empty);
                    entities?.AUTOR?.Add(Autor);
                    entities?.SaveChanges();
                }
                return new Response<AUTOR>()
                {
                    Data = Autor
                };
            }
            catch (Exception ex)
            {
                return new Response<AUTOR>()
                {
                    Data = null,
                    Exception = ex,
                    HttpStatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }

        public Response<bool> Editar(AUTOR Autor)
        {
            try
            {
                AUTOR first = entities?.AUTOR?.FirstOrDefault(x => x.ID == Autor.ID);
                if (first != null)
                {
                    first.NOMBRECOMPLETO = Autor?.NOMBRECOMPLETO;
                    first.FECHANACIMIENTO = Autor?.FECHANACIMIENTO;
                    first.CIUDADPROCEDENCIA = Autor.CIUDADPROCEDENCIA;
                    first.CORREOELECTRONICO = Autor?.CORREOELECTRONICO;
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

        public Response<bool> Eliminar(AUTOR Autor)
        {
            try
            {
                AUTOR first = entities?.AUTOR?.FirstOrDefault(x => x.ID == Autor.ID);
                if (first != null)
                {
                    entities?.AUTOR?.Remove(first);
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