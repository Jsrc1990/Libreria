using Libreria.Proxy;
using Libreria.Repository;
using System.Collections.Generic;
using TransversalLibrary;

namespace Libreria.FrontBusiness
{
    /// <summary>
    /// Define la lógica del Ciudad en el front
    /// </summary>
    public class CiudadFrontBusiness
    {
        /// <summary>
        /// Define el repositorio de las Ciudades
        /// </summary>
        private readonly CiudadProxy CiudadProxy;

        /// <summary>
        /// Inicializa las propiedades de esta clase
        /// </summary>
        public CiudadFrontBusiness()
        {
            CiudadProxy = new CiudadProxy();
        }

        /// <summary>
        /// Obtiene las Ciudades
        /// </summary>
        public Response<IEnumerable<CIUDAD>> Consultar(string valor = "")
        {
            //Otras lógicas...
            return CiudadProxy?.Consultar(valor);
        }

        /// <summary>
        /// Inserta la Ciudad
        /// </summary>
        public Response<CIUDAD> Insertar(CIUDAD CiudadModel)
        {
            //Otras lógicas...
            return CiudadProxy?.Insertar(CiudadModel);
        }

        /// <summary>
        /// Edita la Ciudad
        /// </summary>
        public Response<bool> Editar(CIUDAD CiudadModel)
        {
            //Otras lógicas...
            return CiudadProxy?.Editar(CiudadModel);
        }

        /// <summary>
        /// Elimina la Ciudad
        /// </summary>
        public Response<bool> Eliminar(CIUDAD CiudadModel)
        {
            //Otras lógicas...
            return CiudadProxy?.Eliminar(CiudadModel);
        }
    }
}