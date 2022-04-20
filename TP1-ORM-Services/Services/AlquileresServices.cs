using TP1_ORM_AccessData.Data;
using TP1_ORM_AccessData.Entities;

namespace TP1_ORM_Services.Services
{
    public class AlquileresServices
    {
        public void ListaReservas()
        {
            using (var _context = new LibreriaDbContext())
            {
                List<Alquiler> reservas = (from a in _context.Alquileres where a.Estado == 1 select a).OrderBy(a => a.Isbn).ToList();
                if(reservas.Count > 0)
                {
                    Console.WriteLine("No hay reservas realizadas");
                    return;
                }
                foreach (Alquiler a in reservas)
                {
                    string detalleLibro = (from l in _context.Libros where l.ISBN == a.Isbn select l).First().ToString();
                    Console.WriteLine("Reserva: " + a.Id + "\n" +
                                      "Fecha de reserva: " + a.FechaReserva.ToString() + "\n" +
                                      "Detalle del libro: " + detalleLibro + "\n" );
                }
            }
        }
    }
}
