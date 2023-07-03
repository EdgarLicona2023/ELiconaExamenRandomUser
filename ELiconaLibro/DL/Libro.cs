using System;
using System.Collections.Generic;

namespace DL;

public partial class Libro
{
    public int IdLibro { get; set; }

    public string Nombre { get; set; } = null!;

    public string FechaPublicacion { get; set; } = null!;

    public string Costo { get; set; }

    public int? IdAutor { get; set; }

    public int? IdEditorial { get; set; }

    public virtual Autor? IdAutorNavigation { get; set; }

    public virtual Editorial? IdEditorialNavigation { get; set; }
    public string NombreAutor { get; set; }
    public string NombreEditorial { get; set; }
}
