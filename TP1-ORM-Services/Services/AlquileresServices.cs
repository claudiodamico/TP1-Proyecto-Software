using TP1_ORM_AccessData.Data;
using TP1_ORM_AccessData.Entities;
using TP1_ORM_Services.Validations;

namespace TP1_ORM_Services.Services
{
    public class AlquileresServices
    {
        private readonly Validate _validate;
        private readonly LibrosServices _librosService;
        private readonly ClientesServices _clientesService;

        public AlquileresServices()
        {
            _validate = new Validate();
            _librosService = new LibrosServices();
            _clientesService = new ClientesServices();
        }
        public void ListaReservas()
        {
            using (var _context = new LibreriaDbContext())
            {
                LibrosServices libros = new LibrosServices();
                List<Alquiler> reservas = (from a in _context.Alquileres where a.Estado == 1 select a).OrderBy(a => a.FechaAlquiler).ToList();
                if(reservas.Count == 0)
                {
                    Console.WriteLine("No hay reservas realizadas");
                    return;
                }
                foreach (Alquiler a in reservas)
                {
                    var detalleLibro = (from l in _context.Libros where l.ISBN == a.ISBN select l).First();
                    Console.WriteLine("Numero de reserva: " + a.Id + "\n" +
                                      "Fecha de reserva: " + a.FechaReserva.Value.ToString("dd/MM/yyyy") + "\n" +
                                      "Detalle del libro: " + "\n" + 
                                                              "ISBN: " + detalleLibro.ISBN + "\n" +
                                                              "Titulo: " + detalleLibro.Titulo + "\n" +
                                                              "Autor: " + detalleLibro.Autor + "\n" +
                                                              "Editorial: " + detalleLibro.Editorial + "\n" +
                                                              "Edicion: " + detalleLibro.Edicion + "\n");
                }
            }          
        }

        public void Registrar(Alquiler alquiler)
        {
            using (var _context = new LibreriaDbContext())
            {
                _context.Alquileres.Add(alquiler);
                _context.SaveChanges();
            }
        }

        public void RegistraAlquiler()
        {
            _librosService.ListaLibros();
            Console.WriteLine("Ingrese Isbn del libro");
            string Isbn = Console.ReadLine();

            var libro = _validate.ValidarLibro(Isbn);
            if (libro == null)
            {
                Console.WriteLine("El libro solicitado no se encuentra en el catalogo.\n" +
                                  "Presione una tecla para volver al menú principal.");
                Console.ReadKey();
                return;
            }
            if (!_librosService.HayStock(Isbn))
            {
                Console.WriteLine("El libro solicitado no se encuentra en Stock.\n" +
                                  "Presione una tecla para volver al menú principal.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Ingrese Dni");
            int dni = int.Parse(Console.ReadLine());
            var cliente = _clientesService.GetCliente(dni);

            if (cliente == null)
            {
                Console.WriteLine("El cliente no está registrado.\n" +
                                  "Por favor registrese en la opcion 1- registrar cliente.\n" +
                                  "Presione una tecla para volver al menú principal.");
                Console.ReadKey();
                return;
            }
            else
            {
                Alquiler alquiler = new Alquiler
                {
                    Cliente = cliente.ClienteId,
                    ISBN = Isbn,
                    Estado = 2,
                    FechaAlquiler = DateTime.Now,
                    FechaDevolucion = DateTime.Now.AddDays(7)
                };

                _librosService.RestarStock(Isbn);
                Registrar(alquiler);
                Console.WriteLine("Se realizó el alquiler exitosamente!" + "\n" +
                                  "Presione una tecla para volver al menú principal.");
                Console.ReadKey();
            }
        }

        public void RegistraReserva()
        {
            try
            {
                _librosService.ListaLibros();
                Console.WriteLine("Ingrese Isbn del libro");
                string Isbn = Console.ReadLine();

                var libro = _validate.ValidarLibro(Isbn);
                if (libro == null)
                {
                    Console.WriteLine("El libro solicitado no se encuentra en el catalogo.\n" +
                                      "Presione una tecla para volver al menú principal.");
                    Console.ReadKey();
                    return;
                }
                if (!_librosService.HayStock(Isbn))
                {
                    Console.WriteLine("El libro solicitado no se encuentra en Stock.\n" +
                                      "Presione una tecla para volver al menú principal.");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("Ingrese Dni");
                int dni = int.Parse(Console.ReadLine());

                Cliente cliente = _clientesService.GetCliente(dni);
                if (cliente == null)
                {
                    Console.WriteLine("El cliente no está registrado.\n" +
                                      "Por favor registrese en la opcion 1- registrar cliente.\n" +
                                      "Presione una tecla para volver al menú principal.");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Alquiler alquiler = new Alquiler
                    {
                        Cliente = cliente.ClienteId,
                        ISBN = Isbn,
                        Estado = 1,
                        FechaReserva = DateTime.Now
                    };

                    _librosService.RestarStock(Isbn);
                    Registrar(alquiler);
                    Console.WriteLine("Se realizó la reserva exitosamente!" + "\n" +
                                      "Presione una tecla para volver al menú principal.");
                    Console.ReadKey();
                }
            }catch (Exception ex)
            {
                Console.WriteLine("error");
            }
            
        }
    }
}
