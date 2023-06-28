using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Login
    {
        public List<object> Objects;

        public int IdLogin { set; get; }
        public string NombreUsuario { set; get; }
        public string ApellidoPaterno { set; get; }
        public string ApellidoMaterno { set; get; }
        public string UserName { set; get; }
        public string Correo { set; get; }
        public byte[] Password { set; get; }
        public List<object> Logins { get; set; }
    }
}
