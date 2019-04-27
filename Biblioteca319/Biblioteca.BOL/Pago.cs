using System;

namespace BibliotecaBOL
{
    public class Pago
    {
        public int Id { get; set; }
        public Activo Activo { get; set; }
        public Tarjeta Tarjeta { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
    }
}
