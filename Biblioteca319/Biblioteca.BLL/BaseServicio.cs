using Biblioteca.DAL;

namespace Biblioteca.BLL
{
    public class BaseServicio
    {
        protected readonly BibliotecaContext _context;

        public BaseServicio(BibliotecaContext context) => _context = context;
    }
}
