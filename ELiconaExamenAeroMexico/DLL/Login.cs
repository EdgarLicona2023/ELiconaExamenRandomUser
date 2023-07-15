using System;
using System.Collections.Generic;

namespace DLL;

public partial class Login
{
    public int IdLogin { get; set; }

    public string Nombre { get; set; } = null!;

    public string ApellidoPaterno { get; set; } = null!;

    public string ApellidoMaterno { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public byte[] Password { get; set; } = null!;
	
}
