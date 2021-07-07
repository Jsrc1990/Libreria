using Libreria.Repository;
using System.Collections.Generic;
using TransversalLibrary;

namespace Libreria.Proxy
{
    /// <summary>
    /// Define el repositorio de los Ciudades
    /// </summary>
    public class CiudadProxy : BaseRepository
    {
        /// <summary>
        /// Define la base
        /// </summary>
        private string Base = "https://localhost:44355/";

        /// <summary>
        /// Obtiene los Ciudades
        /// </summary>
        public Response<IEnumerable<CIUDAD>> Consultar(string valor = "")
        {
            string queries = string.IsNullOrWhiteSpace(valor) ? string.Empty : string.Format("?valor={0}", valor);
            string url = Base + "api/Ciudad/Consultar" + queries;
            Response<Response<IEnumerable<CIUDAD>>> response = webClientConnector?.Get<Response<IEnumerable<CIUDAD>>>(url);
            return response?.Data;
        }

        /// <summary>
        /// Inserta el Ciudad
        /// </summary>
        /// <param name="CiudadModel"></param>
        /// <returns>El Ciudad con el nuevo id</returns>
        public Response<CIUDAD> Insertar(CIUDAD CiudadModel)
        {
            string url = Base + "api/Ciudad/Insertar";
            Response<Response<CIUDAD>> response = webClientConnector?.Post<Response<CIUDAD>>(url, CiudadModel);
            return response?.Data;
        }

        /// <summary>
        /// Edita el Ciudad
        /// </summary>
        /// <param name="CiudadModel"></param>
        /// <returns>Verdadero o falso</returns>
        public Response<bool> Editar(CIUDAD CiudadModel)
        {
            string url = Base + "api/Ciudad/Editar";
            Response<Response<bool>> response = webClientConnector?.Post<Response<bool>>(url, CiudadModel);
            return response?.Data;
        }

        /// <summary>
        /// Elimina el Ciudad
        /// </summary>
        /// <param name="CiudadModel"></param>
        /// <returns>Verdadero o falso</returns>
        public Response<bool> Eliminar(CIUDAD CiudadModel)
        {
            string queries = string.IsNullOrWhiteSpace(CiudadModel?.ID) ? string.Empty : string.Format("?id={0}", CiudadModel?.ID);
            string url = Base + "api/Ciudad/Eliminar" + queries;
            Response<Response<bool>> response = webClientConnector?.Post<Response<bool>>(url, CiudadModel);
            return response?.Data;
        }
    }
}