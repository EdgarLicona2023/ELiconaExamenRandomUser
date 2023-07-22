using System;
using System.Collections.Generic;

namespace DL;

public partial class Puesto
{
    public int IdPuesto { get; set; }

    public string Puesto1 { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
	public string Puestos { get; set; }
}
