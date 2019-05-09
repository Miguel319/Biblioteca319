using System.Linq;
using System.Threading.Tasks;
using Biblioteca.DAL;
using Biblioteca319.Models.Sucursal;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca319.Controllers
{
    public class SucursalController : Controller
    {
        private readonly ISucursal _sucursal;

        public SucursalController(ISucursal sucursal) => _sucursal = sucursal;

        public async Task<IActionResult> Index()
        {
            var sucursales = _sucursal.TodasLasSucursales()
                .Select(x => new SucursalDetalleModel
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    EstaAbierta = _sucursal.EstaAbierta(x.Id),
                    NumActivos = _sucursal.TodosLosActivos(x.Id).Count(),
                    NumClientes = _sucursal.TodosLosClientes(x.Id).Count()
                });

            var modelo = new SucursalIndexModel
            {
                Sucursales = sucursales
            };
            return View(modelo);
        }

        public async Task<IActionResult> Detalles(int id)
        {
            var sucursal = await _sucursal.ObtenerPorId(id);

            var modelo = new SucursalDetalleModel
            {
                Id = sucursal.Id,
                Nombre = sucursal.Nombre,
                Direccion = sucursal.Direccion,
                Telefono = sucursal.Telefono,
                FechaApertura = sucursal.FechaApertura.ToString("d"),
                NumActivos = _sucursal.TodosLosActivos(sucursal.Id).Count(),
                NumClientes = _sucursal.TodosLosClientes(sucursal.Id).Count(),
                TotalActivosValor = _sucursal.TodosLosActivos(sucursal.Id).Sum(x => x.Costo),
                ImagenUrl = sucursal.ImagenURL,
                EstaAbierta = _sucursal.EstaAbierta(sucursal.Id),
                HorasAbiertas = _sucursal.ObtenerHorasDeLaSucursal(id)
            };

            return View(modelo);
        }


    }
}