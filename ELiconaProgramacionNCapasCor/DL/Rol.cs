﻿using System;
using System.Collections.Generic;

namespace DL;

public partial class Rol
{
    public string NombreRol;

    public int IdRol { get; set; }

    public string Nombre { get; set; } = null!;
    //public string NombreRol { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
