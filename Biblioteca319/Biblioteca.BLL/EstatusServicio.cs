using System.Collections.Generic;
using System.Threading.Tasks;
using Biblioteca.DAL;
using BibliotecaBOL;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.BLL
{
    public class EstatusServicio : BaseServicio, IEstatus
    {
        public EstatusServicio(BibliotecaContext context) : base(context) {}

        public async Task<IEnumerable<Estatus>> Todos() => await _context.Estatus.ToListAsync();

        public async Task<Estatus> ObtenerPorId(int id) => await _context.Estatus.FindAsync(id);

        public async Task Agregar(Estatus estatus)
        {
            await _context.Estatus.AddAsync(estatus);
            await _context.SaveChangesAsync();
        }

        public async Task Actualizar(Estatus estatus)
        {
            _context.Entry(estatus).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            _context.Estatus.Remove(await ObtenerPorId(id));
            await _context.SaveChangesAsync();
        }

        public string ObtenerNombre(int id) => ObtenerPorId(id)
            .Result.Nombre;
    }
}
