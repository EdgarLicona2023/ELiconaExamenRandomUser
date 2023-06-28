using System;
using System.Collections.Generic;

namespace DL;

public partial class Login
{
    public int IdLogin { get; set; }

    public string? NombreUsuario { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public string? UserName { get; set; }

    public string? Correo { get; set; }

    public byte[]? Password { get; set; }
}
