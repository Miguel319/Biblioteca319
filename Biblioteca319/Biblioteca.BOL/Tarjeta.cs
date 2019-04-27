using System;
using System.Collections.Generic;

namespace BibliotecaBOL
{
    public class Tarjeta
    {
        public int Id { get; set; }
        public decimal Cargos { get; set; }
        public DateTime Creada { get; set; }
        public virtual IEnumerable<Pago> Pagos { get; set; }

    }
}
