using Biblioteca.DAL;
using BibliotecaBOL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            if (EstaPago(activoId))
            {
                return;
                // 
            }

            var articulo = _context.Activos
                .FirstOrDefault(x => x.Id == activoId);

            ActualizarEstatusDeActivo(activoId, "Pago");
            var tarjeta = _context.Tarjetas
                .Include(x => x.Pagos)
                .FirstOrDefault(x => x.Id == tarjetaId);


            var ahora = DateTime.Now;

            var pago = new Pago
            {
                Activo = articulo,
                Tarjeta = tarjeta,
                Desde = ahora,
                Hasta = ObtenerFechaPago(ahora)
            };

            _context.Add(pago);

            var historialDePagos = new PagosHistorial
            {
                Pago = ahora,
                Activo = articulo,
                Tarjeta = tarjeta
            };

            _context.Add(historialDePagos);

            _context.SaveChanges();
        }

        private DateTime ObtenerFechaPago(in DateTime ahora)
        {
            return ahora.AddDays(30);
        }

        public bool EstaPago(int activoId) => _context
                .Pagos.Where(x => x.Activo.Id == activoId).Any();

        public void FacturarArticulo(int activoId, int tarjetaId)
        {
            var ahora = DateTime.Now;

            var articulo = _context.Activos.Find(activoId);

            // Remover pagos existentes en el artículo
            RemoverPagosExistentes(activoId);
            // Remover historial de pagos
            RemoverHistorialDePagosExistentes(activoId);
            // Buscar congelamientos existentes en el artículo
            var congelamientosActuales = _context.Retenciones
                .Include(x => x.Activo)
                .Include(x => x.Tarjeta)
                .Where(x => x.Activo.Id == activoId);

            /*Si hay congelamientos, vincular artículo con la última tarjeta
              con un congelamiento*/
            if (congelamientosActuales.Any())
                VincularUltimoCongelamiento(activoId, congelamientosActuales);
            //Actualizar estatus a disponible
             ActualizarEstatusDeActivo(activoId, "Disponible");
             _context.SaveChanges();
        }

      

        private void VincularUltimoCongelamiento(int activoId, IQueryable<Retencion> congelamientosActuales)
        {
            var ultimosCongelamientos = congelamientosActuales
                .OrderBy(x => x.RetencionPuesta)
                .FirstOrDefault();

            var tarjeta = ultimosCongelamientos.Tarjeta;

            _context.Remove(ultimosCongelamientos);
            _context.SaveChanges();
            PagarArticulo(activoId, tarjeta.Id);
        }

        public IEnumerable<PagosHistorial> ObtenerPagosHistorial(int id) =>
                _context.PagosHistoriall
                .Include(x => x.Activo)
                .Include(x => x.Tarjeta)
                .Where(x => x.Activo.Id == id);

        public void Congelar(int activoId, int tarjetaId)
        {
            var ahora = DateTime.Now;

            var activo = _context.Activos
                .FirstOrDefault(x => x.Id == activoId);

            var tarjeta = _context.Tarjetas
                .FirstOrDefault(x => x.Id == tarjetaId);

            if (activo.Estatus.Nombre == "Disponible")
            {
                ActualizarEstatusDeActivo(activoId, "Congelado");
            }

            var congelamiento = new Retencion
            {
                RetencionPuesta = ahora,
                Activo = activo,
                Tarjeta = tarjeta
            };

            _context.Add(congelamiento);
            _context.SaveChanges();
        }

        public string ObtenerClienteCongelamientoActual(int id)
        {
            var congelamiento = _context.Retenciones
                .Include(x => x.Activo)
                .Include(x => x.Tarjeta)
                .FirstOrDefault(x => x.Id == id);

            var tarjetaId = congelamiento?.Id;

            var cliente = _context.Clientes.Include(x => x.Tarjeta)
                .FirstOrDefault(x => x.Tarjeta.Id == tarjetaId);

            return cliente?.Nombre + " " + cliente?.Apellido;
        }

        public DateTime ObtenerCongelamientoPuesto(int id) =>
             _context.Retenciones
                .Include(x => x.Activo)
                .Include(x => x.Tarjeta)
                .FirstOrDefault(x => x.Id == id)
                .RetencionPuesta;

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

        private void ActualizarEstatusDeActivo(int id, string nuevoEstatus)
        {
            var estatus = _context.Activos.FirstOrDefault(x => x.Id == id);

            _context.Update(estatus);

            estatus.Estatus = _context.Estatus
                .FirstOrDefault(x => x.Nombre == nuevoEstatus);
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

        public string ObtenerClientePagoActual(int id)
        {
            var pago = ObtenerPagoPorIdActivo(id);

            if (pago == null)
            {
                return "";
            }

            var tarjetaId = pago.Tarjeta.Id;

            var cliente = _context.Clientes
                .Include(x => x.Tarjeta)
                .FirstOrDefault(x => x.Tarjeta.Id == tarjetaId);

            return cliente?.Nombre+ " "+cliente?.Apellido;
        }

        private Pago ObtenerPagoPorIdActivo(int id) =>
            _context.Pagos
                .Include(x => x.Activo)
                .Include(x => x.Tarjeta)
                .FirstOrDefault(x => x.Tarjeta.Id == id);

    }

}
