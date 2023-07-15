using System;
using System.Collections.Generic;

namespace DLL;

public partial class Vuelo
{
    public int IdVuelo { get; set; }

    public string NumeroVuelo { get; set; } = null!;

    public string Origen { get; set; } = null!;

    public string Destino { get; set; } = null!;

    public DateTime? FechaSalida { get; set; }

    public virtual ICollection<ReservacionVuelo> ReservacionVuelos { get; set; } = new List<ReservacionVuelo>();
}
