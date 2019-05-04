using Biblioteca.DAL;
using Biblioteca319.Models.Catalogo;
using Biblioteca319.Models.PagoModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca319.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly IActivo _obj;
        private readonly IPago _pago;

        public CatalogoController(IActivo obj, IPago pago)
        {
            _obj = obj;
            _pago = pago;
        }

        public async Task<IActionResult> Index()
        {
            var activos = await _obj.Todos();

            var listadoResultado = activos
                .Select(x => new ActivoIndexModel()
                {
                    Id =  x.Id,
                    ImagenUrl = x.ImagenUrl,
                    AutorODirector = _obj.ObtenerAutorODirector(x.Id),
                    IndiceDewey = _obj.ObtenerIndiceDewey(x.Id),
                    Titulo = x.Titulo,
                    Tipo = _obj.ObtenerTipo(x.Id)
                });

            var modelo = new ActivoModel()
            {
                Activos = listadoResultado
            };

            return View(modelo);
        }

        public async Task<IActionResult> Detalles(int id)
        {
            var activo = await _obj.ObtenerPorId(id);

            var congelamientosActuales = _pago.ObtenerCongelamientosActuales(id)
                .Select(x => new RetencionModel
                {
                   RetencionPuesta = _pago.ObtenerCongelamientoPuesto(x.Id).ToString("d"),
                   NombreCliente = _pago.ObtenerClienteCongelamientoActual(x.Id)
                });

            var modelo = new ActivoDetalleModel
            {
                Id = activo.Id,
                Titulo = activo.Titulo,
                Tipo = _obj.ObtenerTipo(id),
                Anio = activo.Anio,
                Costo = activo.Costo,
                Estatus = activo.Estatus.Nombre,
                ImagenUrl = activo.ImagenUrl,
                AutorODirector = _obj.ObtenerAutorODirector(id),
                UbicacionActual = _obj.ObtenerUbicacionActual(id).Nombre,
                IndiceDewey = _obj.ObtenerIndiceDewey(id),
                PagosHistorial = _pago.ObtenerPagosHistorial(id),
                ISBN = _obj.ObtenerISBN(id),
                UltimoPago = _pago.ObtenerUltimoPago(id),
                NombreCliente = _pago.ObtenerClientePagoActual(id),
                RetencionesActuales = congelamientosActuales
            };

            return View(modelo);
        }

        public async Task<IActionResult> Pagar(int id)
        {
            var activo = await _obj.ObtenerPorId(id);

            var modelo = new PagoModel
            {
                ActivoId = id,
                ImagenUrl = activo.ImagenUrl,
                Titulo = activo.Titulo,
                TarjetaId = "",
                EstaPago = _pago.EstaPago(id)
            };

            return View(modelo);
        }
        [HttpPost]
        public IActionResult Pagar(int activoId, int tarjetaId)
        {
            _pago.PagarArticulo(activoId, tarjetaId);
            return RedirectToAction("Detalles", new { id = activoId });
        }

        public IActionResult Facturar(int id)
        {
            _pago.FacturarArticulo(id);
            return RedirectToAction("Detalles", new {id = id});

        }

        public async  Task<IActionResult> Congelar(int id)
        {
            var activo = await _obj.ObtenerPorId(id);

            var modelo = new PagoModel
            {
                ActivoId = id,
                ImagenUrl = activo.ImagenUrl,
                Titulo = activo.Titulo,
                TarjetaId = "",
                EstaPago = _pago.EstaPago(id),
                NumCongelamientos = _pago.ObtenerCongelamientosActuales(id).Count()
            };

            return View(modelo);
        }

        [HttpPost]
        public IActionResult Congelar(int activoId, int tarjetaId)
        {
            _pago.Congelar(activoId, tarjetaId);
            return RedirectToAction("Detalles", new { id = activoId });
        }

        public IActionResult MarcarComoPerdido(int activoId)
        {
            _pago.MarcarComoPerdido(activoId);
            return RedirectToAction("Detalles", new {id = activoId});
        }
    }
}