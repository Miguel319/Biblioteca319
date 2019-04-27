using BibliotecaBOL;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.DAL
{
    public class BibliotecaContext : DbContext
    {
       public BibliotecaContext(DbContextOptions options): base(options) { }

       public DbSet<Cliente> Clientes { get; set; }
       public DbSet<Libro> Libros { get; set; }
       public DbSet<Video> Videos { get; set; }
       public DbSet<Pago> Pagos { get; set; }
       public DbSet<PagosHistorial> PagosHistoriall { get; set; }
       public DbSet<Sucursal> Sucursales { get; set; }
       public DbSet<SucursalHoras> SucursalHoras { get; set; }
       public DbSet<Estatus> Estatus { get; set; }
       public DbSet<Activo> Activos { get; set; }
       public DbSet<Retencion> Retenciones { get; set; }
    }
}
