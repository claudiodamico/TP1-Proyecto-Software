using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_ORM_AccessData.Entities
{
    public class Alquiler
    {
        public int Id { get; set; }
        public int? Cliente { get; set; }
        public string Isbn { get; set; }
        public int? Estado { get; set; }
        public DateTime? FechaAlquiler { get; set; }
        public DateTime? FechaReserva { get; set; }
        public DateTime? FechaDevolucion { get; set; }

        public virtual Cliente ClienteNavigation { get; set; }
        public virtual EstadoDeAlquiler EstadoNavigation { get; set; }
        public virtual Libro IsbnNavigation { get; set; }
    }
}
