using System;
using System.Collections.Generic;

namespace DLL;

public partial class EstadoCivil
{
    public int IdEstadoCivil { get; set; }

    public string EstadoCivil1 { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    public string EstadoCivill { get; set; }
}
