using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.DAL;
using BibliotecaBOL;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.BLL
{
    public class PagoServicio: BaseServicio, IPago
    {
        public PagoServicio(BibliotecaContext context) : base(context) { }


        public async Task<IEnumerable<Pago>> Todos() => await _context.Pagos
            .ToListAsync();



        public async Task<Pago> ObtenerPorId(int id) => await _context.Pagos
            .FindAsync(id);

        public async Task Agregar(Pago pago)
        {
           await _context.Pagos.AddAsync(pago);
           await _context.SaveChangesAsync();
        }

        public void PagarArticulo(int activoId, int tarjetaId)
        {
            throw new NotImplementedException();
        }

        public void FacturarArticulo(int activoId, int tarjetaId)
        {
            var ahora = DateTime.Now;

            var articulo = _context.Activos.Find(activoId);

            _context.Update(articulo);

            // Remover pagos existentes en el artículo
            // Remover historial de pagos
            // Buscar congelamientos existentes en el artículo

        }

        public IEnumerable<PagosHistorial> ObtenerPagosHistorial(int id) =>
                _context.PagosHistoriall
                .Include(x => x.Activo)
                .Include(x => x.Tarjeta)
                .Where(x => x.Activo.Id == id);

        public void Congelar(int activoId, int tarjetaId)
        {
            throw new NotImplementedException();
        }

        public string ObtenerClienteCongelamientoActual(int id)
        {
            throw new NotImplementedException();
        }

        public DateTime ObtenerCongelamientoPuesto(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Retencion> ObtenerCongelamientosActuales(int id)
        {
            return _context.Retenciones
                .Include(x => x.Activo)
                .Where(x => x.Activo.Id == id);
        }

        public void MarcarComoPerdido(int id)
        {
            ActualizarEstatusDeActivo(id, "Perdido");
            _context.SaveChanges();

        }

        public void MarcarComoEncontrado(int id)
        {
            ActualizarEstatusDeActivo(id, "Disponible");

            RemoverPagosExistentes(id);
            RemoverHistorialDePagosExistentes(id);

            _context.SaveChanges();
        }

        private void ActualizarEstatusDeActivo(int id, string disponible)
        {
            var estatus = _context.Activos.FirstOrDefault(x => x.Id == id);

            _context.Update(estatus);

            estatus.Estatus = _context.Estatus
                .FirstOrDefault(x => x.Nombre == "Disponible");
        }

        private void RemoverHistorialDePagosExistentes(int id)
        {
            var historial = _context.PagosHistoriall
                .FirstOrDefault(x => x.Activo.Id == id
                                     && x.Facturado == null);

            if (historial != null)
            {
                _context.Update(historial);
                historial.Facturado = DateTime.Now;
            }

        }

        private void RemoverPagosExistentes(int id)
        {
            var pago = _context.Pagos
                .FirstOrDefault(x => x.Activo.Id == id);

            if (pago != null)
            {
                _context.Remove(pago);
            }
        }

        public Pago ObtenerUltimoPago(int id) =>  _context.Pagos
            .Where(x => x.Activo.Id == id)
                .OrderByDescending(x => x.Desde)
                .FirstOrDefault();
    }
}
