using System;
using System.Collections.Generic;

namespace PROYECTORADIX.Models;

public partial class Ficha
{
    public int Id { get; set; }

    public int IdPrograma { get; set; }

    public int IdJornada { get; set; }

    public int IdTipoFormacion { get; set; }

    public int IdModalidad { get; set; }

    public DateTime FechaIniciolectiva { get; set; }

    public DateTime FechaFinallectiva { get; set; }

    public DateTime FechaIniciopractica { get; set; }

    public DateTime FechaFinalpractica { get; set; }

    public int IdInstructorlider { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<Aprendiz> Aprendizs { get; set; } = new List<Aprendiz>();

    public virtual Jornadum IdJornadaNavigation { get; set; } = null!;

    public virtual Modalidad IdModalidadNavigation { get; set; } = null!;

    public virtual Programa IdProgramaNavigation { get; set; } = null!;

    public virtual TipoFormacion IdTipoFormacionNavigation { get; set; } = null!;
}
