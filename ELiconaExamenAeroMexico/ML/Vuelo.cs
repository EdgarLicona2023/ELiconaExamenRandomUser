using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
	public class Vuelo
	{
		public int IdVuelo { get; set; }
		public string NumeroVuelo { get; set; }
		public string Origen { get; set; }
		public string Destino { get; set; }
		public DateTime FechaSalida { get; set; }
		public List<object> Vuelos { get; set; }

	}
}
