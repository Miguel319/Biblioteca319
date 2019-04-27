using System;
using System.ComponentModel;

namespace BibliotecaBOL
{
    public class Retencion
    {
        public int Id { get; set; }
        public virtual Activo Activo { get; set; }
        public virtual Tarjeta Tarjeta { get; set; }
        [DisplayName("Fecha")]
        public DateTime RetencionPuesta{ get; set; }

    }
}
