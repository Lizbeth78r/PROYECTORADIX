using System;
using System.Collections.Generic;

namespace PROYECTORADIX.Models;

public partial class Aprendiz
{
    public int NumeroId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Telefono1 { get; set; } = null!;

    public string? Telefono2 { get; set; }

    public string Correo1 { get; set; } = null!;

    public string? Correo2 { get; set; }

    public string Direccion { get; set; } = null!;

    public int IdMunicipio { get; set; }

    public int IdFicha { get; set; }

    public DateTime FechaNacimiento { get; set; }

    public string Rh { get; set; } = null!;

    public int IdTipodocumento { get; set; }

    public string? Observacion { get; set; }

    public bool Estado { get; set; }

    public virtual Ficha IdFichaNavigation { get; set; } = null!;

    public virtual Municipio IdMunicipioNavigation { get; set; } = null!;

    public virtual Tipodocumento IdTipodocumentoNavigation { get; set; } = null!;

    public virtual ICollection<Novedad> Novedads { get; set; } = new List<Novedad>();
}
