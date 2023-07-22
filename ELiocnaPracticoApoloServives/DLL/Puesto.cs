using System;
using System.Collections.Generic;

namespace DLL;

public partial class Puesto
{
    public int IdPuesto { get; set; }

    public string Puestos { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
