using System;
using System.Collections.Generic;

namespace DLL;

public partial class Departamento
{
    public int IdDepartamento { get; set; }

    public string Departamentos { get; set; } = null!;

    public int? IdArea { get; set; }

    public virtual Area? IdAreaNavigation { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
