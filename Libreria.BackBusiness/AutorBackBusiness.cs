using Libreria.BackBusiness.Interfaces;
using Libreria.Repository;
using System.Collections.Generic;
using TransversalLibrary;

namespace Libreria.BackBusiness
{
    public class AutorBackBusiness : IAutorBackBusiness
    {
        private readonly AutorRepository AutorRepository;

        public AutorBackBusiness()
        {
            AutorRepository = new AutorRepository();
        }

        public Response<IEnumerable<AUTOR>> Consultar(string valor)
        {
            //Otras lógicas...
            return AutorRepository?.Consultar(valor);
        }

        public Response<AUTOR> Insertar(AUTOR Autor)
        {
            //Otras lógicas...
            return AutorRepository?.Insertar(Autor);
        }

        public Response<bool> Editar(AUTOR Autor)
        {
            //Otras lógicas...
            return AutorRepository?.Editar(Autor);
        }

        public Response<bool> Eliminar(AUTOR Autor)
        {
            //Otras lógicas...
            return AutorRepository?.Eliminar(Autor);
        }
    }
}