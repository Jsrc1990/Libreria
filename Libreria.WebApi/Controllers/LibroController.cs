using Libreria.BackBusiness.Interfaces;
using Libreria.Repository;
using System.Collections.Generic;
using System.Web.Http;
using TransversalLibrary;

namespace Libreria.WebApi.Controllers
{
    /// <summary>
    /// Define el controlador de los libros
    /// </summary>
    public class LibroController : ApiController
    {
        /// <summary>
        /// Define la lógica
        /// </summary>
        private readonly ILibroBackBusiness LibroBackBusiness;

        /// <summary>
        /// Inicializa las propiedades de esta clase
        /// </summary>
        /// <param name="libroBackBusiness"></param>
        public LibroController(ILibroBackBusiness libroBackBusiness)
        {
            LibroBackBusiness = libroBackBusiness;
        }

        [HttpGet]
        [Route("api/Libro/Consultar")]
        public Response<IEnumerable<LIBRO>> Consultar(string valor = "")
        {
            Response<IEnumerable<LIBRO>> response = LibroBackBusiness?.Consultar(valor);
            return response;
        }

        [HttpPost]
        [Route("api/Libro/Insertar")]
        public Response<LIBRO> Insertar([FromBody] LIBRO Libro)
        {
            Response<LIBRO> response = LibroBackBusiness?.Insertar(Libro);
            return response;
        }

        [HttpPost]
        [Route("api/Libro/Editar")]
        public Response<bool> Put([FromBody] LIBRO Libro)
        {
            Response<bool> response = LibroBackBusiness?.Editar(Libro);
            return response;
        }

        [HttpPost]
        [Route("api/Libro/Eliminar")]
        public Response<bool> Delete(string id)
        {
            Response<bool> response = LibroBackBusiness?.Eliminar(new LIBRO()
            {
                ID = id
            });
            return response;
        }
    }
}
