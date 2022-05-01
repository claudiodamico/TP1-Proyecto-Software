using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1_ORM_AccessData.Data;

namespace TP1_ORM_Services.Validations
{
    public class Validate
    {
        //Validamos existencia de libro
        public string ValidarLibro(string Isbn)
        {
            using (var _context = new LibreriaDbContext())
            {
                var libro = _context.Libros.Find(Isbn);
                if (libro != null)
                {
                    return libro.ToString();
                }
                else
                {
                    Console.WriteLine("ISBN invalido");
                }
                return ("");
            }
        }

        //Validamos si hay stock existente
        public bool ValidarStock(string Isbn)
        {
            using (var _context = new LibreriaDbContext())
            {
                int stock = (from s in _context.Libros where s.ISBN == Isbn select s.Stock).FirstOrDefault();
                if (stock > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
