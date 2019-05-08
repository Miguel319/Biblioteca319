using System.Collections.Generic;
using Biblioteca.DAL;
using Biblioteca319.Models.Cliente;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaBOL;

namespace Biblioteca319.Controllers
{
    public class ClienteController : Controller
    {
        private ICliente _cliente;

        public ClienteController(ICliente cliente) => _cliente = cliente;

        public async Task<IActionResult> Index()
        {
            var clientes = await _cliente.ObtenerTodos();

            var clienteModelos = clientes.Select(p => new ClienteDetalleModelo
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                TarjetaId = p.Tarjeta.Id,
                Cargos = p.Tarjeta.Cargos,
                SucursalALaQuePertenece = p.SucursalAsociada.Nombre
            }).ToList();

            var modelo = new ClienteIndexModel
            {
                Clientes = clienteModelos
            };

            return View(modelo);
        }
        
        public async Task<IActionResult> Detalles(int id)
        {
            var cliente = await _cliente.ObtenerPorId(id);

            var modelo = new ClienteDetalleModelo
            {
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Direccion = cliente.Direccion,
                SucursalALaQuePertenece = cliente.SucursalAsociada.Nombre,
                MiembroDesde = cliente.Tarjeta.Creada,
                Cargos = cliente.Tarjeta.Cargos,
                TarjetaId = cliente.Tarjeta.Id,
                Telefono = cliente.Telefono,
                ActivosPagos = _cliente.ObtenerPagos(id).ToList()
                               ?? new List<Pago>(),
                HistorialDePagos = _cliente.ObtenerHistorialDePago(id),
                Congelamientos = _cliente.ObtenerRetenciones(id)
            };

            return View(modelo);
        }
    }
}