using TP1_ORM_AccessData.Data;
using TP1_ORM_AccessData.Entities;
using TP1_ORM_Services.Services;

namespace TP1_ORM_Services.Business
{
    public class LibrosInfo
    {
        public List<Libro> GetLibros()
        {
            using (var _context = new LibreriaDbContext())
            {
                return _context.Libros.ToList();
            }
        }
    }
}
