using System.Collections.Generic;
using TransversalLibrary;

namespace Libreria.BackBusiness.Interfaces
{
    public interface ICrudBusiness<T>
    {
        Response<IEnumerable<T>> Consultar(string valor);

        Response<T> Insertar(T categoriaModel);

        Response<bool> Editar(T categoriaModel);

        Response<bool> Eliminar(T categoriaModel);
    }
}
