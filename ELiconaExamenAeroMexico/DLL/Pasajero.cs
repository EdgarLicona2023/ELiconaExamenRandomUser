using System;
using System.Collections.Generic;

namespace DLL;

public partial class Pasajero
{
    public int IdPasajero { get; set; }

    public string Nombre { get; set; } = null!;

    public string ApellidoPaterno { get; set; } = null!;

    public string ApellidoMaterno { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public byte[] Password { get; set; } = null!;

    public virtual ICollection<ReservacionVuelo> ReservacionVuelos { get; set; } = new List<ReservacionVuelo>();
}
