using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public ML.Puesto Puesto { set; get; }
        public ML.Departamento Departamento { set; get; }

        public List<object> Empleados { get; set; }
    }
}
