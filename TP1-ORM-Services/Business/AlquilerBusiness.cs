using TP1_ORM_Services.Services;

namespace TP1_ORM_Services.Business
{
    public class AlquilerBusiness
    {
        public void ListarReservas()
        {
            AlquileresServices alquileres = new AlquileresServices();
            alquileres.ListaReservas();

        }
    }
}
