using System;
using System.Collections.Generic;

namespace DL_EF;

public partial class Cine
{
    public int IdCine { get; set; }

    public string NombreCine { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public decimal Ventas { get; set; }

    public int? IdZona { get; set; }

    public virtual Zona? IdZonaNavigation { get; set; }
    public string NombreZona { get; set; }
}
