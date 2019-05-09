using System.Collections.Generic;
using System.Threading.Tasks;
using BibliotecaBOL;

namespace Biblioteca.DAL
{
    public interface ISucursal
    {
        IEnumerable<Sucursal> TodasLasSucursales();
        IEnumerable<Cliente> TodosLosClientes(int sucursalId);
        IEnumerable<Activo> TodosLosActivos(int activoId);
        IEnumerable<string> ObtenerHorasDeLaSucursal(int sucursalId);
        Task<Sucursal> ObtenerPorId(int sucursalId);
        Task Agregar(Sucursal sucursal);
        bool EstaAbierta(int sucursalId);
    }
}
