using TP1_ORM_Services.Services;

namespace TP1_ORM_Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            string op;
            do
            {
                Console.Clear();
                Console.WriteLine("*******************************************************************\n" +
                                  "****                     Libreria Municipal                    ****\n" +
                                  "*******************************************************************\n");
                Console.WriteLine("Bienvenido a la libreria Municipal. Por favor, seleccione una opción del menú: \n\n");
                Console.WriteLine("1) Registrar cliente\n" +
                                  "2) Registrar un alquiler\n" +
                                  "3) Registrar una reserva\n" +
                                  "4) Ver Reservas\n" +
                                  "5) Ver libros en stock\n" +
                                  "6) Salir del programa.");

                op = Console.ReadLine();
                switch (op)
                {
                    case "1":
                        Console.Clear();
                        //RegistrarCliente();
                        break;

                    case "2":
                        Console.Clear();
                        //RegistrarAlquiler();

                        break;

                    case "3":
                        Console.Clear();
                        //RegistrarReserva();

                        break;

                    case "4":
                        Console.Clear();
                        //VerReservas();
                        break;

                    case "5":
                        Console.Clear();
                        VerLibrosInfo();
                        break;

                    case "6":
                        Console.Clear();
                        Console.WriteLine("Saliendo del programa");
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("La opción ingresada no es correcta, por favor inténtelo nuevamente.");
                        Console.WriteLine("Presione enter para continuar.");
                        Console.ReadLine();
                        break;
                }
            } while (op != "6");
        }

        static void VerLibrosInfo()
        {
            var service = new LibrosServices();
            Console.WriteLine("Lista de libros en stock\n");
            service.ListaLibros();
            Console.WriteLine("\n");
            Console.WriteLine("Presione enter para continuar y volver al menú principal.");
            Console.ReadKey();
        }
    }
}




