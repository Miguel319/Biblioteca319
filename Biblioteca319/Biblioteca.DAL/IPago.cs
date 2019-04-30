using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BibliotecaBOL;

namespace Biblioteca.DAL
{
    public interface IPago
    {
        Task<IEnumerable<Pago>> Todos();
        Task<Pago> ObtenerPorId(int id);
        Task Agregar(Pago pago);
        void PagarArticulo(int activoId, int tarjetaId);
        void FacturarArticulo(int activoId, int tarjetaId);
        IEnumerable<PagosHistorial> ObtenerPagosHistorial(int id);

        void Congelar(int activoId, int tarjetaId);
        string ObtenerClienteCongelamientoActual(int id);
        DateTime ObtenerCongelamientoPuesto(int id);
        IEnumerable<Retencion> ObtenerCongelamientosActuales(int id);

        void MarcarComoPerdido(int id);
        void MarcarComoEncontrado(int id);
        Pago ObtenerUltimoPago(int id);
    }
}

