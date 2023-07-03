using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Libro
    {
        public int IdLibro { get; set; }
        public string Nombre { get; set; }
        public string FechaPublicacion { get; set; }
        public string Costo { get; set; }
        public List<object> Libros { get; set; }
        public ML.Editorial Editorial { get; set; }
        public ML.Autor Autor { get; set; }
    }
}
