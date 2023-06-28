using System;
using System.Collections.Generic;

namespace DL_EF;

public partial class Login
{
    public int IdLogin { get; set; }

    public string UserName { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Password { get; set; } = null!;
}
