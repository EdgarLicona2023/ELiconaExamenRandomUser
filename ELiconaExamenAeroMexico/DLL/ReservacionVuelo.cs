using System;
using System.Collections.Generic;

namespace DLL;

public partial class ReservacionVuelo
{
    public int IdReservacionVuelos { get; set; }

    public int? IdPasajero { get; set; }

    public int? IdVuelo { get; set; }

    public virtual Pasajero? IdPasajeroNavigation { get; set; }

    public virtual Vuelo? IdVueloNavigation { get; set; }
}
