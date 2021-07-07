using Libreria.Proxy;
using Libreria.Repository;
using System.Collections.Generic;
using TransversalLibrary;

namespace Libreria.FrontBusiness
{
    /// <summary>
    /// Define la lógica del Genero en el front
    /// </summary>
    public class GeneroFrontBusiness
    {
        /// <summary>
        /// Define el repositorio de los géneros
        /// </summary>
        private readonly GeneroProxy GeneroProxy;

        /// <summary>
        /// Inicializa las propiedades de esta clase
        /// </summary>
        public GeneroFrontBusiness()
        {
            GeneroProxy = new GeneroProxy();
        }

        /// <summary>
        /// Obtiene los géneros
        /// </summary>
        public Response<IEnumerable<GENERO>> Consultar(string valor = "")
        {
            //Otras lógicas...
            return GeneroProxy?.Consultar(valor);
        }

        /// <summary>
        /// Inserta el Genero
        /// </summary>
        public Response<GENERO> Insertar(GENERO GeneroModel)
        {
            //Otras lógicas...
            return GeneroProxy?.Insertar(GeneroModel);
        }

        /// <summary>
        /// Edita el Genero
        /// </summary>
        public Response<bool> Editar(GENERO GeneroModel)
        {
            //Otras lógicas...
            return GeneroProxy?.Editar(GeneroModel);
        }

        /// <summary>
        /// Elimina el Genero
        /// </summary>
        public Response<bool> Eliminar(GENERO GeneroModel)
        {
            //Otras lógicas...
            return GeneroProxy?.Eliminar(GeneroModel);
        }
    }
}