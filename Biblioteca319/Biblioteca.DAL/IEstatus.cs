using System.Collections.Generic;
using System.Threading.Tasks;
using BibliotecaBOL;

namespace Biblioteca.DAL
{
    public interface IEstatus
    {
        Task<IEnumerable<Estatus>> Todos();
        Task<Estatus> ObtenerPorId(int id);

        Task Agregar(Estatus estatus);
        Task Actualizar(Estatus estatus);
        Task Eliminar(int id);
        string ObtenerNombre(int id);
    }
}
