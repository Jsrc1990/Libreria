using Libreria.BackBusiness.Interfaces;
using Libreria.Repository;
using System.Collections.Generic;
using System.Web.Http;
using TransversalLibrary;

namespace Libreria.WebApi.Controllers
{
    /// <summary>
    /// Define el controlador de los géneros
    /// </summary>
    public class GeneroController : ApiController
    {
        /// <summary>
        /// Define la lógica
        /// </summary>
        private readonly IGeneroBackBusiness GeneroBackBusiness;

        /// <summary>
        /// Inicializa las propiedades de esta clase
        /// </summary>
        /// <param name="generoBackBusiness"></param>
        public GeneroController(IGeneroBackBusiness generoBackBusiness)
        {
            GeneroBackBusiness = generoBackBusiness;
        }

        [HttpGet]
        [Route("api/Genero/Consultar")]
        public Response<IEnumerable<GENERO>> Consultar(string valor = "")
        {
            Response<IEnumerable<GENERO>> response = GeneroBackBusiness?.Consultar(valor);
            return response;
        }

        [HttpPost]
        [Route("api/Genero/Insertar")]
        public Response<GENERO> Insertar([FromBody] GENERO Genero)
        {
            Response<GENERO> response = GeneroBackBusiness?.Insertar(Genero);
            return response;
        }

        [HttpPost]
        [Route("api/Genero/Editar")]
        public Response<bool> Put([FromBody] GENERO Genero)
        {
            Response<bool> response = GeneroBackBusiness?.Editar(Genero);
            return response;
        }

        [HttpPost]
        [Route("api/Genero/Eliminar")]
        public Response<bool> Delete(string id)
        {
            Response<bool> response = GeneroBackBusiness?.Eliminar(new GENERO()
            {
                ID = id
            });
            return response;
        }
    }
}