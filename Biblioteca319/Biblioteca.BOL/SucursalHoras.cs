using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaBOL
{
    public class SucursalHoras
    {
        public int Id { get; set; }
        public Sucursal Sucursal { get; set; }
        [Range(0,6)]
        [DisplayName("Día")]
        public int DiaSemana { get; set; }
        [Range(0, 23)]
        [DisplayName("Hora de apertura")]
        public int HoraApertura { get; set; }
        [Range(0,23)]
        [DisplayName("Hora de cierre")]
        public int HoraCierre{ get; set; }
    }
}
