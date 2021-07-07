using Libreria.Proxy;
using Libreria.Repository;
using System.Collections.Generic;
using TransversalLibrary;

namespace Libreria.FrontBusiness
{
    /// <summary>
    /// Define la lógica del autor en el front
    /// </summary>
    public class AutorFrontBusiness
    {
        /// <summary>
        /// Define el repositorio de las Autores
        /// </summary>
        private readonly AutorProxy AutorProxy;

        /// <summary>
        /// Inicializa las propiedades de esta clase
        /// </summary>
        public AutorFrontBusiness()
        {
            AutorProxy = new AutorProxy();
        }

        /// <summary>
        /// Obtiene las Autores
        /// </summary>
        public Response<IEnumerable<AUTOR>> Consultar(string valor = "")
        {
            //Otras lógicas...
            return AutorProxy?.Consultar(valor);
        }

        /// <summary>
        /// Inserta la Autor
        /// </summary>
        public Response<AUTOR> Insertar(AUTOR AutorModel)
        {
            //Otras lógicas...
            return AutorProxy?.Insertar(AutorModel);
        }

        /// <summary>
        /// Edita la Autor
        /// </summary>
        public Response<bool> Editar(AUTOR AutorModel)
        {
            //Otras lógicas...
            return AutorProxy?.Editar(AutorModel);
        }

        /// <summary>
        /// Elimina la Autor
        /// </summary>
        public Response<bool> Eliminar(AUTOR AutorModel)
        {
            //Otras lógicas...
            return AutorProxy?.Eliminar(AutorModel);
        }
    }
}