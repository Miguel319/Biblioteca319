using System.Collections.Generic;
using System.Threading.Tasks;
using BibliotecaBOL;

namespace Biblioteca.DAL
{
    public interface ICliente
    {
        Task<Cliente> ObtenerPorId(int id);
        Task<IEnumerable<Cliente>> ObtenerTodos();
        Task Agregar(Cliente cliente);

        IEnumerable<PagosHistorial> ObtenerHistorialDePago(int clienteId);
        IEnumerable<Retencion> ObtenerRetenciones(int clienteId);
        IEnumerable<Pago> ObtenerPagos(int clienteId);
    }
}
