using TP1_ORM_Services.Services;

namespace TP1_ORM_Services.Business
{
    public class AlquilerBusiness
    {
        private readonly AlquileresServices _services;

        public AlquilerBusiness(AlquileresServices services)
        {
            _services = new AlquileresServices();
        }
        public void ListarReservas()
        {
            _services.ListaReservas();

        }
        public void RegistrarAlquiler()
        {
            _services.RegistraAlquiler();
        }
        public void RegistrarReserva()
        {
            _services.RegistraReserva();
        }

    }
}
