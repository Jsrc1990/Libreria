using Libreria.BackBusiness.Interfaces;
using Libreria.Repository;
using System.Collections.Generic;
using System.Web.Http;
using TransversalLibrary;

namespace Libreria.WebApi.Controllers
{
    /// <summary>
    /// Define el controlador de los autores
    /// </summary>
    public class AutorController : ApiController
    {
        /// <summary>
        /// Define la lógica
        /// </summary>
        private readonly IAutorBackBusiness AutorBackBusiness;

        /// <summary>
        /// Inicializa las propiedades de esta clase
        /// </summary>
        /// <param name="autorBackBusiness"></param>
        public AutorController(IAutorBackBusiness autorBackBusiness)
        {
            AutorBackBusiness = autorBackBusiness;
        }

        [HttpGet]
        [Route("api/Autor/Consultar")]
        public Response<IEnumerable<AUTOR>> Consultar(string valor = "")
        {
            Response<IEnumerable<AUTOR>> response = AutorBackBusiness?.Consultar(valor);
            return response;
        }

        [HttpPost]
        [Route("api/Autor/Insertar")]
        public Response<AUTOR> Insertar([FromBody] AUTOR autor)
        {
            Response<AUTOR> response = AutorBackBusiness?.Insertar(autor);
            return response;
        }

        [HttpPost]
        [Route("api/Autor/Editar")]
        public Response<bool> Put([FromBody] AUTOR autor)
        {
            Response<bool> response = AutorBackBusiness?.Editar(autor);
            return response;
        }

        [HttpPost]
        [Route("api/Autor/Eliminar")]
        public Response<bool> Delete(string id)
        {
            Response<bool> response = AutorBackBusiness?.Eliminar(new AUTOR()
            {
                ID = id
            });
            return response;
        }
    }
}
