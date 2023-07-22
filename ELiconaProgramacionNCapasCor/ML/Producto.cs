using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ML
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioUnitario { get; set; } //{0,255}
        public int Stock { get; set; }
        public string Descripcion { get; set; }


        public ML.Area Area { set; get; }
        public ML.Departamento Departamento { set; get; }
        public ML.Proveedor Proveedor { set; get; }

        public List<object> Productos { get; set; }
    }

}
