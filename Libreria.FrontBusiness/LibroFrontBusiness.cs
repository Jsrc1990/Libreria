using Libreria.Proxy;
using Libreria.Repository;
using System.Collections.Generic;
using TransversalLibrary;

namespace Libreria.FrontBusiness
{
    /// <summary>
    /// Define la lógica del libro en el front
    /// </summary>
    public class LibroFrontBusiness
    {
        /// <summary>
        /// Define el repositorio de los Libros
        /// </summary>
        private readonly LibroProxy LibroProxy;

        /// <summary>
        /// Inicializa las propiedades de esta clase
        /// </summary>
        public LibroFrontBusiness()
        {
            LibroProxy = new LibroProxy();
        }

        /// <summary>
        /// Obtiene los Libros
        /// </summary>
        public Response<IEnumerable<LIBRO>> Consultar(string valor = "")
        {
            //Otras lógicas...
            return LibroProxy?.Consultar(valor);
        }

        /// <summary>
        /// Inserta el Libro
        /// </summary>
        public Response<LIBRO> Insertar(LIBRO LibroModel)
        {
            //Otras lógicas...
            return LibroProxy?.Insertar(LibroModel);
        }

        /// <summary>
        /// Edita el Libro
        /// </summary>
        public Response<bool> Editar(LIBRO LibroModel)
        {
            //Otras lógicas...
            return LibroProxy?.Editar(LibroModel);
        }

        /// <summary>
        /// Elimina el Libro
        /// </summary>
        public Response<bool> Eliminar(LIBRO LibroModel)
        {
            //Otras lógicas...
            return LibroProxy?.Eliminar(LibroModel);
        }
    }
}