using Libreria.Repository;
using System.Collections.Generic;
using TransversalLibrary;

namespace Libreria.Proxy
{
    /// <summary>
    /// Define el repositorio de los géneros
    /// </summary>
    public class GeneroProxy : BaseRepository
    {
        /// <summary>
        /// Define la base
        /// </summary>
        private string Base = "https://localhost:44355/";

        /// <summary>
        /// Obtiene los géneros
        /// </summary>
        public Response<IEnumerable<GENERO>> Consultar(string valor = "")
        {
            string queries = string.IsNullOrWhiteSpace(valor) ? string.Empty : string.Format("?valor={0}", valor);
            string url = Base + "api/Genero/Consultar" + queries;
            Response<Response<IEnumerable<GENERO>>> response = webClientConnector?.Get<Response<IEnumerable<GENERO>>>(url);
            return response?.Data;
        }

        /// <summary>
        /// Inserta el Genero
        /// </summary>
        /// <param name="GeneroModel"></param>
        /// <returns>El Genero con el nuevo id</returns>
        public Response<GENERO> Insertar(GENERO GeneroModel)
        {
            string url = Base + "api/Genero/Insertar";
            Response<Response<GENERO>> response = webClientConnector?.Post<Response<GENERO>>(url, GeneroModel);
            return response?.Data;
        }

        /// <summary>
        /// Edita el Genero
        /// </summary>
        /// <param name="GeneroModel"></param>
        /// <returns>Verdadero o falso</returns>
        public Response<bool> Editar(GENERO GeneroModel)
        {
            string url = Base + "api/Genero/Editar";
            Response<Response<bool>> response = webClientConnector?.Post<Response<bool>>(url, GeneroModel);
            return response?.Data;
        }

        /// <summary>
        /// Elimina el Genero
        /// </summary>
        /// <param name="GeneroModel"></param>
        /// <returns>Verdadero o falso</returns>
        public Response<bool> Eliminar(GENERO GeneroModel)
        {
            string queries = string.IsNullOrWhiteSpace(GeneroModel?.ID) ? string.Empty : string.Format("?id={0}", GeneroModel?.ID);
            string url = Base + "api/Genero/Eliminar" + queries;
            Response<Response<bool>> response = webClientConnector?.Post<Response<bool>>(url, GeneroModel);
            return response?.Data;
        }
    }
}