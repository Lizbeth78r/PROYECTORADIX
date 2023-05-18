using System;
using System.Collections.Generic;

namespace PROYECTORADIX.Models;

public partial class Programa
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Creditos { get; set; } = null!;

    public string VersionPrograma { get; set; } = null!;

    public string DuracionLectiva { get; set; } = null!;

    public string DuracionProductiva { get; set; } = null!;

    public int IdTipodeformacion { get; set; }

    public string Duraciontotal { get; set; } = null!;

    public int IdRed { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<Ficha> Fichas { get; set; } = new List<Ficha>();

    public virtual Red IdRedNavigation { get; set; } = null!;

    public virtual TipoFormacion IdTipodeformacionNavigation { get; set; } = null!;

    public virtual ICollection<ProgramaCompetencium> ProgramaCompetencia { get; set; } = new List<ProgramaCompetencium>();

    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();
}
