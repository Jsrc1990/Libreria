using Libreria.BackBusiness.Interfaces;
using Libreria.Repository;
using System.Collections.Generic;
using TransversalLibrary;

namespace Libreria.BackBusiness
{
    public class CiudadBackBusiness : ICiudadBackBusiness
    {
        private readonly CiudadRepository CiudadRepository;

        public CiudadBackBusiness()
        {
            CiudadRepository = new CiudadRepository();
        }

        public Response<IEnumerable<CIUDAD>> Consultar(string valor)
        {
            //Otras lógicas...
            return CiudadRepository?.Consultar(valor);
        }

        public Response<CIUDAD> Insertar(CIUDAD ciudad)
        {
            //Otras lógicas...
            return CiudadRepository?.Insertar(ciudad);
        }

        public Response<bool> Editar(CIUDAD ciudad)
        {
            //Otras lógicas...
            return CiudadRepository?.Editar(ciudad);
        }

        public Response<bool> Eliminar(CIUDAD ciudad)
        {
            //Otras lógicas...
            return CiudadRepository?.Eliminar(ciudad);
        }
    }
}