using TP1_ORM_Services.Services;

namespace TP1_ORM_Services.Business
{
    public class LibrosBusiness
    {
        public void ListarLibros()
        {
            LibrosServices libros = new LibrosServices();

            libros.ListaLibros();

        }
    }
}
