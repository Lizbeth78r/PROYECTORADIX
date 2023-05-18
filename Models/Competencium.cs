using System;
using System.Collections.Generic;

namespace PROYECTORADIX.Models;

public partial class Competencium
{
    public int Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public string Duracion { get; set; } = null!;

    public int? IdResultadoApren { get; set; }

    public bool Estado { get; set; }

    public virtual Resultadoaprendizaje? IdResultadoAprenNavigation { get; set; }

    public virtual ICollection<ProgramaCompetencium> ProgramaCompetencia { get; set; } = new List<ProgramaCompetencium>();
}
