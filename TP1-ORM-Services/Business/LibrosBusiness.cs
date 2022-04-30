using TP1_ORM_Services.Services;

namespace TP1_ORM_Services.Business
{
    public class LibrosBusiness
    {
        private readonly LibrosServices _services;

        public LibrosBusiness(LibrosServices services)
        {
            _services = services;
        }
        public void ListarLibros()
        {
            _services.ListaLibros();
        }
    }
}
