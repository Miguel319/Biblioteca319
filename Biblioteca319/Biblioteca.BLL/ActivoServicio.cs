using Biblioteca.DAL;
using BibliotecaBOL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.BLL
{
    public class ActivoServicio : BaseServicio, IActivo
    {
        public ActivoServicio(BibliotecaContext context): base(context) { }

        public async Task<IEnumerable<Activo>> Todos() => await
            _context.Activos
                .Include(x => x.Estatus)
                .Include(x => x.Ubicacion)
                .ToListAsync();


        public async Task<Activo> ObtenerPorId(int id) => await _context.Activos
            .Include(x => x.Estatus)
            .Include(x => x.Ubicacion)
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task Agregar(Activo activo)
        {
            await _context.Activos.AddAsync(activo);
            await _context.SaveChangesAsync();
        } 

        public async Task Actualizar(Activo activo)
        {
            _context.Entry(activo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            var activo = await ObtenerPorId(id);
            _context.Activos.Remove(activo);
            await _context.SaveChangesAsync();
        }

        public string ObtenerAutorODirector(int id)
        {
            var esLibro = _context.Activos.OfType<Libro>()
                .Where(x => x.Id == id).Any();

            return esLibro
                ? _context.Libros.FirstOrDefault(x => x.Id == id).Autor
                : _context.Videos.FirstOrDefault(x => x.Id == id) .Director
                  ?? "Desconocido";
        }

        public string ObtenerIndiceDewey(int id)
        {
            if (_context.Libros.Any(x => x.Id == id))
            {
                return _context.Libros.FirstOrDefault(x => x.Id == id).IndiceDewey;
            }

            return "";
        }

        public string ObtenerTipo(int id)
        {
            var libro = _context.Activos.OfType<Libro>()
                .Where(x => x.Id == id);

            return libro.Any() ? "Libro" : "Video";
        }

        public string ObtenerTitulo(int id) => _context.Activos.
            FirstOrDefault(x => x.Id == id).Titulo;

        public string ObtenerISBN(int id)
        {
            if (_context.Libros.Any(x => x.Id == id))
            {
                return _context.Libros.FirstOrDefault(x => x.Id == id).ISBN;
            }

            return "";
        }

        public Sucursal ObtenerUbicacionActual(int id) =>
            ObtenerPorId(id).Result.Ubicacion;
    }


}
