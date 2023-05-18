using System;
using System.Collections.Generic;

namespace PROYECTORADIX.Models;

public partial class ProgramaCompetencium
{
    public int Id { get; set; }

    public int? IdCompetencia { get; set; }

    public int? IdPrograma { get; set; }

    public virtual Competencium? IdCompetenciaNavigation { get; set; }

    public virtual Programa? IdProgramaNavigation { get; set; }
}
