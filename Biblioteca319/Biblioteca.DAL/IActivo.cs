using System.Collections.Generic;
using System.Threading.Tasks;
using BibliotecaBOL;

namespace Biblioteca.DAL
{
    public interface IActivo
    {
        Task<IEnumerable<Activo>> Todos();
        Task<Activo> ObtenerPorId(int id);
        Task Agregar(Activo activo);
        Task Actualizar(Activo activo);
        Task Eliminar(int id);
        string ObtenerAutorODirector(int id);
        string ObtenerIndiceDewey(int id);
        string ObtenerTipo(int id);
        string ObtenerTitulo(int id);
        string ObtenerISBN(int id);

        Sucursal ObtenerUbicacionActual(int id);
    }
}
