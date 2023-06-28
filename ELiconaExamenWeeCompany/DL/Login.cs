using System;
using System.Collections.Generic;

namespace DL;

public partial class Login
{
    public int IdLogin { get; set; }

    public string Nombre { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Empresa { get; set; } = null!;

    public byte[]? Password { get; set; }
}
