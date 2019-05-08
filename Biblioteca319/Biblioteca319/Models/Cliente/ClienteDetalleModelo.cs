using System;
using System.Collections.Generic;
using BibliotecaBOL;

namespace Biblioteca319.Models.Cliente
{
    public class ClienteDetalleModelo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreCompleto { get => Nombre + " " + Apellido; } 
        public int TarjetaId { get; set; }
        public string Direccion { get; set; }
        public DateTime MiembroDesde { get; set; }
        public string Telefono { get; set; }
        public string SucursalALaQuePertenece { get; set; }
        public decimal Cargos { get; set; }
        public IEnumerable<Pago> ActivosPagos { get; set; }
        public IEnumerable<PagosHistorial> HistorialDePagos { get; set; }
        public IEnumerable<Retencion> Congelamientos { get; set; }
    }
}