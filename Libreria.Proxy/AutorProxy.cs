using Libreria.Repository;
using System.Collections.Generic;
using TransversalLibrary;

namespace Libreria.Proxy
{
    /// <summary>
    /// Define el repositorio de los Autores
    /// </summary>
    public class AutorProxy : BaseRepository
    {
        /// <summary>
        /// Define la base
        /// </summary>
        private string Base = "https://localhost:44355/";

        /// <summary>
        /// Obtiene los Autores
        /// </summary>
        public Response<IEnumerable<AUTOR>> Consultar(string valor = "")
        {
            string queries = string.IsNullOrWhiteSpace(valor) ? string.Empty : string.Format("?valor={0}", valor);
            string url = Base + "api/Autor/Consultar" + queries;
            Response<Response<IEnumerable<AUTOR>>> response = webClientConnector?.Get<Response<IEnumerable<AUTOR>>>(url);
            return response?.Data;
        }

        /// <summary>
        /// Inserta el Autor
        /// </summary>
        /// <param name="AutorModel"></param>
        /// <returns>El Autor con el nuevo id</returns>
        public Response<AUTOR> Insertar(AUTOR AutorModel)
        {
            string url = Base + "api/Autor/Insertar";
            Response<Response<AUTOR>> response = webClientConnector?.Post<Response<AUTOR>>(url, AutorModel);
            return response?.Data;
        }

        /// <summary>
        /// Edita el Autor
        /// </summary>
        /// <param name="AutorModel"></param>
        /// <returns>Verdadero o falso</returns>
        public Response<bool> Editar(AUTOR AutorModel)
        {
            string url = Base + "api/Autor/Editar";
            Response<Response<bool>> response = webClientConnector?.Post<Response<bool>>(url, AutorModel);
            return response?.Data;
        }

        /// <summary>
        /// Elimina el Autor
        /// </summary>
        /// <param name="AutorModel"></param>
        /// <returns>Verdadero o falso</returns>
        public Response<bool> Eliminar(AUTOR AutorModel)
        {
            string queries = string.IsNullOrWhiteSpace(AutorModel?.ID) ? string.Empty : string.Format("?id={0}", AutorModel?.ID);
            string url = Base + "api/Autor/Eliminar" + queries;
            Response<Response<bool>> response = webClientConnector?.Post<Response<bool>>(url, AutorModel);
            return response?.Data;
        }
    }
}