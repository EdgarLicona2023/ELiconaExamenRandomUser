using System;
using System.Collections.Generic;

namespace DLL;

public partial class Area
{
    public int IdArea { get; set; }

    public string Areas { get; set; } = null!;

    public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();
}
