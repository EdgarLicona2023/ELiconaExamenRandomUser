using System;
using System.Collections.Generic;

namespace DL;

public partial class Sexo
{
    public int IdSexo { get; set; }

    public string Sexo1 { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
	public string Sexos { get; set; }
}
