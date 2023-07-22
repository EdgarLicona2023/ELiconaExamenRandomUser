using System;
using System.Collections.Generic;

namespace DL;

public partial class Usuario
{
    public int IdUser { get; set; }

    public string UserName { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string ApellidoPaterno { get; set; } = null!;

    public string ApellidoMaterno { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FechaNacimiento { get; set; } = null!;

    public decimal? Telefono { get; set; }

    public byte[]? Imagen { get; set; }

    public int? IdSexo { get; set; }

    public int? IdEstadoCivil { get; set; }

    public int? IdPuesto { get; set; }

    public int? IdDepartamento { get; set; }

    public virtual Departamento? IdDepartamentoNavigation { get; set; }

    public virtual EstadoCivil? IdEstadoCivilNavigation { get; set; }

    public virtual Puesto? IdPuestoNavigation { get; set; }

    public virtual Sexo? IdSexoNavigation { get; set; }
    //public virtual Area? IdAreaNavigation { get; set; }
	public string Sexo { get; set; }
	public string EstadoCivil { get; set; }
	public string Puesto { get; set; }
	public string Departamento { get; set; }
	public string Area { get; set; }
	public int? IdArea { get; set; }
    public string Areas { get; set; }
}
