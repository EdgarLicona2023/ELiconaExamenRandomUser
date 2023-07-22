using System;
using System.Collections.Generic;

namespace DLL;

public partial class Sexo
{
    public int IdSexo { get; set; }

    public string Sexos { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
