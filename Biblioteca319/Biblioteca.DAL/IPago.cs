using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BibliotecaBOL;

namespace Biblioteca.DAL
{
    public interface IPago
    {
        Task<IEnumerable<Pago>> Todos();
        Task Agregar(Pago pago);
        IEnumerable<PagosHistorial> ObtenerPagosHistorial(int id);
        IEnumerable<Retencion> ObtenerCongelamientosActuales(int id);



        Task<Pago> ObtenerPorId(int id);
        void PagarArticulo(int activoId, int tarjetaId);
        void FacturarArticulo(int activoId, int tarjetaId);
        string ObtenerClientePagoActual(int id);
        bool EstaPago(int id);


        void Congelar(int activoId, int tarjetaId);
        string ObtenerClienteCongelamientoActual(int id);
        DateTime ObtenerCongelamientoPuesto(int id);

        void MarcarComoPerdido(int id);
        void MarcarComoEncontrado(int id);
        Pago ObtenerUltimoPago(int id);
    }
}

