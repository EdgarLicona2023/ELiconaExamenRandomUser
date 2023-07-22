using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
	public class Usuario
	{
		public int IdUser { get; set; }
		public string UserName { get; set; }
		public string Nombre { get; set; }
		public string ApellidoPaterno { get; set; }
		public string ApellidoMaterno { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string FechaNacimiento { get; set; }
		public decimal Telefono { get; set; }
		public byte[] Imagen { get; set; }
		public ML.Sexo Sexo { get; set; }
		public ML.EstadoCivilS EstadoCivil { get; set; }
		public ML.Puesto Puesto { get; set; }
		public ML.Departamento Departamento { get; set; }
		public ML.Area Area { get; set; }
		public List<object> Usuarios { get; set;}

	}
}
