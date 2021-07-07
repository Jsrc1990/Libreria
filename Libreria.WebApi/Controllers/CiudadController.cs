using Libreria.BackBusiness.Interfaces;
using Libreria.Repository;
using System.Collections.Generic;
using System.Web.Http;
using TransversalLibrary;

namespace Libreria.WebApi.Controllers
{
    /// <summary>
    /// Define el controlador de los Ciudades
    /// </summary>
    public class CiudadController : ApiController
    {
        /// <summary>
        /// Define la lógica
        /// </summary>
        private readonly ICiudadBackBusiness CiudadBackBusiness;

        /// <summary>
        /// Inicializa las propiedades de esta clase
        /// </summary>
        /// <param name="ciudadBackBusiness"></param>
        public CiudadController(ICiudadBackBusiness ciudadBackBusiness)
        {
            CiudadBackBusiness = ciudadBackBusiness;
        }

        [HttpGet]
        [Route("api/Ciudad/Consultar")]
        public Response<IEnumerable<CIUDAD>> Consultar(string valor = "")
        {
            Response<IEnumerable<CIUDAD>> response = CiudadBackBusiness?.Consultar(valor);
            return response;
        }

        [HttpPost]
        [Route("api/Ciudad/Insertar")]
        public Response<CIUDAD> Insertar([FromBody] CIUDAD Ciudad)
        {
            Response<CIUDAD> response = CiudadBackBusiness?.Insertar(Ciudad);
            return response;
        }

        [HttpPost]
        [Route("api/Ciudad/Editar")]
        public Response<bool> Put([FromBody] CIUDAD Ciudad)
        {
            Response<bool> response = CiudadBackBusiness?.Editar(Ciudad);
            return response;
        }

        [HttpPost]
        [Route("api/Ciudad/Eliminar")]
        public Response<bool> Delete(string id)
        {
            Response<bool> response = CiudadBackBusiness?.Eliminar(new CIUDAD()
            {
                ID = id
            });
            return response;
        }
    }
}
