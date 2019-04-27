using System;

namespace BibliotecaBOL
{
    public class PagosHistorial
    {
        public int Id { get; set; }
        public Activo Activo { get; set; }
        public Tarjeta Tarjeta { get; set; }
        public DateTime Pago { get; set; }
        public DateTime? Facturado { get; set; }

    }
}
