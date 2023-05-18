using System;
using System.Collections.Generic;

namespace PROYECTORADIX.Models;

public partial class Usuario
{
    public int NumeroId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public int IdMunicipio { get; set; }

    public int IdArea { get; set; }

    public int IdTipoContrato { get; set; }

    public int IdTipoUsuario { get; set; }

    public DateTime FechaInicioContrato { get; set; }

    public DateTime FechaFinContrato { get; set; }

    public bool Estado { get; set; }

    public virtual Area IdAreaNavigation { get; set; } = null!;

    public virtual Municipio IdMunicipioNavigation { get; set; } = null!;

    public virtual TipoContrato IdTipoContratoNavigation { get; set; } = null!;

    public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Novedad> Novedads { get; set; } = new List<Novedad>();
}
