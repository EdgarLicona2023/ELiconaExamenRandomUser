using System;
using System.Collections.Generic;

namespace DL;

public partial class Direccion
{
    public int IdDireccion { get; set; }

    public string Calle { get; set; } = null!;

    public string? NumeroExterior { get; set; }

    public string NumeroInterior { get; set; } = null!;

    public int? IdUsuario { get; set; }

    public int? IdColonia { get; set; }

    public virtual Colonium? IdColoniaNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
