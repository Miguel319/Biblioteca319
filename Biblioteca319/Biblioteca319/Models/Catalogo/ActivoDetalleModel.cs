using System.Collections.Generic;
using BibliotecaBOL;

namespace Biblioteca319.Models.Catalogo
{
    public class ActivoDetalleModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string AutorODirector { get; set; }
        public string Tipo { get; set; }
        public int Anio { get; set; }
        public string ISBN { get; set; }
        public string IndiceDewey { get; set; }
        public string Estatus { get; set; }
        public decimal Costo { get; set; }
        public string UbicacionActual { get; set; }
        public string ImagenUrl { get; set; }
        public string NombreCliente { get; set; }
        public Pago UltimoPago { get; set; }
        public IEnumerable<PagosHistorial> PagosHistorial { get; set; }
        public IEnumerable<RetencionModel> RetencionesActuales { get; set; }
    }

    public class RetencionModel
    {
        public string NombreCliente { get; set; }
        public string RetencionPuesta { get; set; }
    }
}