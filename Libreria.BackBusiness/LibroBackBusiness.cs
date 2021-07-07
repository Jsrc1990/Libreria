using Libreria.BackBusiness.Interfaces;
using Libreria.Repository;
using System.Collections.Generic;
using TransversalLibrary;

namespace Libreria.BackBusiness
{
    public class LibroBackBusiness : ILibroBackBusiness
    {
        private readonly LibroRepository LibroRepository;

        public LibroBackBusiness()
        {
            LibroRepository = new LibroRepository();
        }

        public Response<IEnumerable<LIBRO>> Consultar(string valor)
        {
            //Otras lógicas...
            return LibroRepository?.Consultar(valor);
        }

        public Response<LIBRO> Insertar(LIBRO libro)
        {
            //Otras lógicas...
            return LibroRepository?.Insertar(libro);
        }

        public Response<bool> Editar(LIBRO libro)
        {
            //Otras lógicas...
            return LibroRepository?.Editar(libro);
        }

        public Response<bool> Eliminar(LIBRO libro)
        {
            //Otras lógicas...
            return LibroRepository?.Eliminar(libro);
        }
    }
}