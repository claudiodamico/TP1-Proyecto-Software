using TP1_ORM_AccessData.Data;
using TP1_ORM_AccessData.Entities;
using TP1_ORM_Services.Validations;

namespace TP1_ORM_Services.Services
{
    public class AlquileresServices
    {
        //Listamos las reservas existentes
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
        //Agergamos el alquiler en la db
        public void Registrar(Alquiler alquiler)
        {
            using (var _context = new LibreriaDbContext())
            {
                _context.Alquileres.Add(alquiler);
                _context.SaveChanges();
            }
        }
        //Registamos un alquiler
        public void RegistraAlquiler()
        {
            Validate validate= new Validate();
            LibrosServices libros = new LibrosServices();
            ClientesServices clientes = new ClientesServices();
            libros.ListaLibros();
            Console.WriteLine("Ingrese Isbn del libro");
            string Isbn = Console.ReadLine();
            //Validamos si hay existencias del libro
            var libro = validate.ValidarLibro(Isbn);
            if (libro == null)
            {
                Console.WriteLine("El libro solicitado no se encuentra en el catalogo.\n" +
                                  "Presione una tecla para volver al menú principal.");
                Console.ReadKey();
                return;
            }
            if (!libros.HayStock(Isbn))
            {
                Console.WriteLine("El libro solicitado no se encuentra en Stock.\n" +
                                  "Presione una tecla para volver al menú principal.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Ingrese Dni");
            int dni = int.Parse(Console.ReadLine());
            var cliente = clientes.GetCliente(dni);
            //Validamos si el cliente existe en nuestra aplicacion
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
                //Restamos al stock y registramos el alquiler
                libros.RestarStock(Isbn);
                Registrar(alquiler);
                Console.WriteLine("Se realizó el alquiler exitosamente!" + "\n" +
                                  "Presione una tecla para volver al menú principal.");
                Console.ReadKey();
            }
        }
        //Registramos una reserva
        public void RegistraReserva()
        {
            try
            {
                Validate validate = new Validate();
                LibrosServices libros = new LibrosServices();
                ClientesServices clientes = new ClientesServices();
                libros.ListaLibros();
                Console.WriteLine("Ingrese Isbn del libro");
                string Isbn = Console.ReadLine();
                //Validamos si hay existencias del libro
                var libro = validate.ValidarLibro(Isbn);
                if (libro == null)
                {
                    Console.WriteLine("El libro solicitado no se encuentra en el catalogo.\n" +
                                      "Presione una tecla para volver al menú principal.");
                    Console.ReadKey();
                    return;
                }
                if (!libros.HayStock(Isbn))
                {
                    Console.WriteLine("El libro solicitado no se encuentra en Stock.\n" +
                                      "Presione una tecla para volver al menú principal.");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("Ingrese Dni");
                int dni = int.Parse(Console.ReadLine());
                //Validamos si el cliente existe en nuestra aplicacion
                Cliente cliente = clientes.GetCliente(dni);
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
                    //Restamos al stock y registramos la reserva
                    libros.RestarStock(Isbn);
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
