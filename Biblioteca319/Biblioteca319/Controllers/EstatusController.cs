using System.Threading.Tasks;
using Biblioteca.DAL;
using BibliotecaBOL;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca319.Controllers
{
    public class EstatusController : Controller
    {
        private IEstatus _obj;

        public EstatusController(IEstatus obj) => _obj = obj;

        public async Task<IActionResult> Index() => View(await _obj.Todos());


        public IActionResult Agregar() => View();

       [HttpPost]
        public async Task<IActionResult> Agregar(Estatus estatus)
        {
            if (ModelState.IsValid)
            {
                await _obj.Agregar(estatus);
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Editar(int id)
        {
            var nombre = _obj.ObtenerNombre(id);
            ViewBag.Nombre = nombre;

            return View(await _obj.ObtenerPorId(id));

        }

        [HttpPost]
        public async Task<IActionResult> Editar(Estatus estatus)
        {
            if (ModelState.IsValid)
            {
                await _obj.Actualizar(estatus);
                return RedirectToAction("Index");
            }

            return View();
        }

    }
}