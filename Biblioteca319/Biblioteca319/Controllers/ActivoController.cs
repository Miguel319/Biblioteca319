using Biblioteca.DAL;
using BibliotecaBOL;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Biblioteca319.Controllers
{
    public class ActivoController : Controller
    {
        private IActivo _obj;

        public ActivoController(IActivo obj) => _obj = obj;

        public async Task<IActionResult> Index() => View(await _obj.Todos());

        public IActionResult Agregar() => View();

        [HttpPost]
        public async Task<IActionResult> Agregar(Activo activo)
        {
            if (ModelState.IsValid)
            {
                await _obj.Agregar(activo);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var label = _obj.ObtenerAutorODirector(id);
            ViewBag.Label = label;

            return View(await _obj.ObtenerPorId(id));
        } 

        [HttpPost]
        public async Task<IActionResult> Editar(Activo activo)
        {
            if (ModelState.IsValid)
            {
                await _obj.Actualizar(activo);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
