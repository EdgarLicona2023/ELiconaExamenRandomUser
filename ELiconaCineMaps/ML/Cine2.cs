using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Cine2
    {
        //public int ID { get; set; }
        public int IdCine { get; set; }
        public string NombreCine { get; set; }
        public string Direccion { get; set; }
        public decimal Ventas { get; set; }

        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        //public string Descripcion { get; set; }
        //public decimal Venta { get; set; }
        public decimal TotalVentas { get; set; }
        public ML.Zona Zona { get; set; }
        public ML.Estadistica Estadistica { get; set; }
        public List<object> PuntoVentas { get; set; }
        public List<object> Cines { get; set; }
    }
}
