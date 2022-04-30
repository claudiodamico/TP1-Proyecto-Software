using TP1_ORM_AccessData.Entities;
using TP1_ORM_Services.Services;

namespace TP1_ORM_Services.Business
{
    public class ClientesBusiness
    {
        private readonly ClientesServices _services;

        public ClientesBusiness(ClientesServices services)
        {
            _services = services;
        }
        public void RegistrarCliente()
        {
            _services.RegistraCliente();
        }
    }
}
