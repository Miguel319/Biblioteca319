using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.DAL;
using BibliotecaBOL;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.BLL
{
    public class ClienteServicio : BaseServicio, ICliente
    {
        public ClienteServicio(BibliotecaContext context) : base(context){}

        public async Task<Cliente> ObtenerPorId(int id) => await _context
            .Clientes
            .Include(x => x.Tarjeta)
            .Include(x => x.SucursalAsociada)
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Cliente>> ObtenerTodos() => await _context
            .Clientes
            .Include(x => x.Tarjeta)
            .Include(x => x.SucursalAsociada)
            .ToListAsync();

        public async Task Agregar(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<PagosHistorial> ObtenerHistorialDePago(int clienteId)
        {
            var tarjetaId = ObtenerPorId(clienteId).Result.Tarjeta.Id;


            return _context.PagosHistoriall
                .Include(x => x.Tarjeta)
                .Include(x => x.Activo)
                .Where(x => x.Tarjeta.Id == tarjetaId)
                .OrderByDescending(x => x.Pago);
        }

        public IEnumerable<Retencion> ObtenerRetenciones(int clienteId)
        {
            var tarjetaId = ObtenerPorId(clienteId).Result.Tarjeta.Id;


            return _context.Retenciones
                .Include(x => x.Tarjeta)
                .Include(x => x.Activo)
                .Where(x => x.Tarjeta.Id == tarjetaId)
                .OrderByDescending(X => X.RetencionPuesta);
        }

        public IEnumerable<Pago> ObtenerPagos(int clienteId)
        {
            var tarjetaId = ObtenerPorId(clienteId).Result.Tarjeta.Id;


            return _context.Pagos
                .Include(x => x.Tarjeta)
                .Include(x => x.Activo)
                .Where(x => x.Tarjeta.Id == tarjetaId);
        }

       
    }
}
