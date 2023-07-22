using System;
using System.Collections.Generic;

namespace DL;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string NombreProducto { get; set; } = null!;

    public decimal PrecioUnitario { get; set; }

    public int Stock { get; set; }

    public string? Descripcion { get; set; }

    public int? IdProveedor { get; set; }

    public int? IdDepartamento { get; set; }

    public virtual Departamento? IdDepartamentoNavigation { get; set; }

    public virtual Proveedor? IdProveedorNavigation { get; set; }

    public string NombreProveedor { get; set; }
    public string TelefonoProveedor { get; set; }
    public string NombreDepartamento { get; set; }
    public string NombreArea { get; set; }
    public int? IdArea { get; set; }


}
