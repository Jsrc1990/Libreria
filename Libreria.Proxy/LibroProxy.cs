using Libreria.Repository;
using System.Collections.Generic;
using TransversalLibrary;

namespace Libreria.Proxy
{
    /// <summary>
    /// Define el repositorio de los libros
    /// </summary>
    public class LibroProxy : BaseRepository
    {
        /// <summary>
        /// Define la base
        /// </summary>
        private string Base = "https://localhost:44355/";

        /// <summary>
        /// Obtiene los libros
        /// </summary>
        public Response<IEnumerable<LIBRO>> Consultar(string valor = "")
        {
            string queries = string.IsNullOrWhiteSpace(valor) ? string.Empty : string.Format("?valor={0}", valor);
            string url = Base + "api/Libro/Consultar" + queries;
            Response<Response<IEnumerable<LIBRO>>> response = webClientConnector?.Get<Response<IEnumerable<LIBRO>>>(url);
            return response?.Data;
        }

        /// <summary>
        /// Inserta el Libro
        /// </summary>
        /// <param name="libro"></param>
        /// <returns>El Libro con el nuevo id</returns>
        public Response<LIBRO> Insertar(LIBRO libro)
        {
            string url = Base + "api/Libro/Insertar";
            Response<Response<LIBRO>> response = webClientConnector?.Post<Response<LIBRO>>(url, libro);
            return response?.Data;
        }

        /// <summary>
        /// Edita el Libro
        /// </summary>
        /// <param name="libro"></param>
        /// <returns>Verdadero o falso</returns>
        public Response<bool> Editar(LIBRO libro)
        {
            string url = Base + "api/Libro/Editar";
            Response<Response<bool>> response = webClientConnector?.Post<Response<bool>>(url, libro);
            return response?.Data;
        }

        /// <summary>
        /// Elimina el Libro
        /// </summary>
        /// <param name="libro"></param>
        /// <returns>Verdadero o falso</returns>
        public Response<bool> Eliminar(LIBRO libro)
        {
            string queries = string.IsNullOrWhiteSpace(libro?.ID) ? string.Empty : string.Format("?id={0}", libro?.ID);
            string url = Base + "api/Libro/Eliminar" + queries;
            Response<Response<bool>> response = webClientConnector?.Post<Response<bool>>(url, libro);
            return response?.Data;
        }
    }
}