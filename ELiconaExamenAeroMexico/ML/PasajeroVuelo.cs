using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
	public class PasajeroVuelo
	{
		public int IdUsuarioVuelos { get; set; }
		public Pasajero Pasajero { get; set; }
		public Vuelo Vuelo { get; set; }
		public List<Object> PasajerosVuelos { get; set; }
	}
}
