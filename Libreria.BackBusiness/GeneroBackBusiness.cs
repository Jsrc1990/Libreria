using Libreria.BackBusiness.Interfaces;
using Libreria.Repository;
using System.Collections.Generic;
using TransversalLibrary;

namespace Libreria.BackBusiness
{
    public class GeneroBackBusiness : IGeneroBackBusiness
    {
        private readonly GeneroRepository GeneroRepository;

        public GeneroBackBusiness()
        {
            GeneroRepository = new GeneroRepository();
        }

        public Response<IEnumerable<GENERO>> Consultar(string valor)
        {
            //Otras lógicas...
            return GeneroRepository?.Consultar(valor);
        }

        public Response<GENERO> Insertar(GENERO genero)
        {
            //Otras lógicas...
            return GeneroRepository?.Insertar(genero);
        }

        public Response<bool> Editar(GENERO genero)
        {
            //Otras lógicas...
            return GeneroRepository?.Editar(genero);
        }

        public Response<bool> Eliminar(GENERO genero)
        {
            //Otras lógicas...
            return GeneroRepository?.Eliminar(genero);
        }
    }
}