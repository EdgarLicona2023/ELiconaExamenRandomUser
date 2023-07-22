using System;
using System.Collections.Generic;

namespace DL;

public partial class Departamento
{
    public int IdDepartamento { get; set; }

    public string Departamento1 { get; set; } = null!;

    public int? IdArea { get; set; }

    public virtual Area? IdAreaNavigation { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
	public string Departamentos { get; set; }
}
