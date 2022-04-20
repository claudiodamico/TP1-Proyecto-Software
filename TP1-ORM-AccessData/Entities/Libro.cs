

namespace TP1_ORM_AccessData.Entities
{
    public class Libro
    {
        public Libro()
        {
            Alquileres = new HashSet<Alquiler>();
        }

        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public string Edicion { get; set; }
        public int Stock { get; set; }
        public string Imagen { get; set; }

        public virtual ICollection<Alquiler> Alquileres { get; set; }
    }
}
