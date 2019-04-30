using System.Linq;
using System.Threading.Tasks;
using Biblioteca.DAL;
using Biblioteca319.Models.Catalogo;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca319.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly IActivo _obj;

        public CatalogoController(IActivo obj) => _obj = obj;

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
        /*
        public async Task<IActionResult> Detalles(int id)
        {
            var activo = await _obj.ObtenerPorId(id);

            var modelo = new ActivoDetalleModel
            {
                Id = id,
                Titulo = activo.Titulo,
                Anio = activo.Anio,
                Costo = activo.Costo,
                Estatus = activo.Estatus.Nombre,
                ImagenUrl = activo.ImagenUrl,
                AutorODirector = _obj.ObtenerAutorODirector(id),
                UbicacionActual = _obj.ObtenerUbicacionActual(id).Nombre,
                IndiceDewey = _obj.ObtenerIndiceDewey(id),
                ISBN = _obj.ObtenerISBN(id)
            };

            return View(modelo);


        }*/
    }
}
