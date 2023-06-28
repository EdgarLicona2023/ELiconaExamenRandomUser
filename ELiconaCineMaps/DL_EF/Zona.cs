using System;
using System.Collections.Generic;

namespace DL_EF;

public partial class Zona
{
    public int IdZona { get; set; }

    public string NombreZona { get; set; } = null!;

    public virtual ICollection<Cine> Cines { get; set; } = new List<Cine>();
    public int IdCine { get; set; }
    public string NombreCine { get; set; }
    public string Direccion { get; set; }
    public decimal Ventas { get; set; }
}
