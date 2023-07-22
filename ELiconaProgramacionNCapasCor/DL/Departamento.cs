﻿using System;
using System.Collections.Generic;

namespace DL;

public partial class Departamento
{
    public int IdDepartamento { get; set; }

    public string NombreDepartamento { get; set; } = null!;

    public int? IdArea { get; set; }

    public virtual Area? IdAreaNavigation { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}