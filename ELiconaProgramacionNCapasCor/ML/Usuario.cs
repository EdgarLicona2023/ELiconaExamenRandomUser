using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        public int Id_Usuario { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidoPaternoUsuario { get; set; }
        public string ApellidoMaternoUsuario { get; set; }
        public string Curp { get; set; }
        public string FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Sexo { get; set; }
        public string Celular { get; set; }

        //public Byte Imagen { get; set; }
        public ML.Rol Rol { get; set; }
        public ML.Direccion Direccion { get; set; }
        public ML.Colonia Colonia { get; set; }
        public ML.Municipio Municipio { get; set; }
        public ML.Estado Estado { get; set; }
        public ML.Pais Pais { get; set; }
        public List<object> Usuarios { get; set; }
    }
}
