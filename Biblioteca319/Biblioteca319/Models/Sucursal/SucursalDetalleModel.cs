using System.Collections.Generic;

namespace Biblioteca319.Models.Sucursal
{
    public class SucursalDetalleModel
    {
        public int Id { get; set; }
        public string Direccion { get; set; }
        public string Nombre { get; set; }
        public string FechaApertura { get; set; }
        public string Telefono { get; set; }
        public bool EstaAbierta { get; set; }
        public string Descripcion { get; set; }
        public int NumClientes { get; set; }
        public int NumActivos { get; set; }
        public decimal TotalActivosValor { get; set; }
        public string ImagenUrl { get; set; }
        public IEnumerable<string> HorasAbiertas { get; set; }
    }
}
