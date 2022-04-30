using TP1_ORM_AccessData.Data;
using TP1_ORM_AccessData.Entities;

namespace TP1_ORM_Services.Services
{
    public class ClientesServices
    {
        //Validamos si existe el cliente
        public Cliente GetCliente(string dni)
        {
            using (var _context = new LibreriaDbContext())
            {
                return _context.Clientes.FirstOrDefault(x => x.Dni == dni);
            }
        }
        //Validamos clientes por dni
        public Cliente GetCliente(int dni)
        {
            return GetCliente(dni.ToString());
        }
        //
        public void Registrar(Cliente cliente)
        {
            using (var _context = new LibreriaDbContext())
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
            }
        }
        ////Registramos un cliente
        public void RegistraCliente()
        {
            Console.WriteLine("Ingrese su Nombre: ");
            string Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese su Apellido: ");
            string Apellido = Console.ReadLine();

            Console.WriteLine("Ingrese su Dni: ");
            string dni = Console.ReadLine();
            var cliente = GetCliente(dni);
            //Validamos si el cliente existe en nuestra aplicacion
            if (cliente !=null)
            {
                Console.WriteLine("El cliente ya esta registrado" + "\n" +
                                   "Presione enter para continuar y volver al menú principal.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Ingrese su Email");
            string Email = Console.ReadLine();
            //Registro de cliente
            Registrar(new Cliente
            {
                Nombre = Nombre,
                Apellido = Apellido,
                Dni = dni,
                Email = Email
            });

            Console.WriteLine("El cliente se registro exitosamente!" + "\n" + 
                              "Presione enter para continuar y volver al menú principal.");
            Console.ReadKey();
        }
    }
}
