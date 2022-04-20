using TP1_ORM_AccessData.Data;
using TP1_ORM_AccessData.Entities;

namespace TP1_ORM_Services.Services
{
    public class LibrosServices
    {
        public void ListaLibros()
        {
            using (var _context = new LibreriaDbContext())
            {
                List<Libro> libros = (from l in _context.Libros where l.Stock > 0 select l).ToList();
                if (libros.Count == 0)
                {
                    Console.WriteLine("No hay ejemplares para alquilar.");
                    return;
                }
                foreach (var libro in libros)
                {
                    Console.WriteLine("Titulo: " + libro.Titulo + " " + "Autor: " + libro.Autor);
                }
            }

        }

        public bool HayStock(string ISBN)
        {
            using (var _context = new LibreriaDbContext())
            {
                int stock = (from l in _context.Libros where l.ISBN == ISBN select l.Stock).FirstOrDefault();
                if (stock > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public void RestarStock(string ISBN)
        {
            using (var _context = new LibreriaDbContext())
            {
                Libro libro = (from l in _context.Libros where l.ISBN == ISBN select l).FirstOrDefault();
                libro.Stock = -1;
                _context.SaveChanges();
            }
        }
    }
}
