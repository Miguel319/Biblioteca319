using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.DAL;
using BibliotecaBOL;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.BLL
{
    public class SucursalServicio : BaseServicio, ISucursal
    {
        public SucursalServicio(BibliotecaContext context) : base(context) { }

        public IEnumerable<Sucursal> TodasLasSucursales() => _context.Sucursales
            .Include(x => x.Clientes)
            .Include(x => x.Activos).ToList();


        public IEnumerable<Cliente> TodosLosClientes(int sucursalId) =>
            _context.Sucursales
                .Include(x => x.Clientes)
                .FirstOrDefault(x => x.Id == sucursalId)
                .Clientes.ToList();

        public IEnumerable<Activo> TodosLosActivos(int activoId) => _context.Sucursales
            .Include( x => x.Activos)
            .FirstOrDefault(x => x.Id == activoId)
            .Activos.ToList();

        public IEnumerable<string> ObtenerHorasDeLaSucursal(int sucursalId)
        {
            var horas = _context.SucursalHoras
                .Where(x => x.Sucursal.Id == sucursalId);

            return DataHelper.SimplificarTiempo(horas);

        }

        public async Task<Sucursal> ObtenerPorId(int sucursalId) => await _context.Sucursales
            .Include(x => x.Clientes)
            .Include(x => x.Activos)
            .FirstOrDefaultAsync(x => x.Id == sucursalId);

        public async Task Agregar(Sucursal sucursal)
        {
            await _context.AddAsync(sucursal);
            await _context.SaveChangesAsync();
        }

        public bool EstaAbierta(int sucursalId)
        {
            var horaActual = DateTime.Now.Hour;
            var diaActual = (int) DateTime.Now.DayOfWeek +1;
            var horas = _context.SucursalHoras.Where(x => x.Sucursal.Id == sucursalId);
            var horasDelDia = horas.FirstOrDefault(x => x.DiaSemana == diaActual);

            return horaActual < horasDelDia.HoraCierre && horaActual > horasDelDia.HoraApertura;
        }

    }
}
