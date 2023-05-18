using System;
using System.Collections.Generic;

namespace PROYECTORADIX.Models;

public partial class Resultadoaprendizaje
{
    public int Codigo { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<Competencium> Competencia { get; set; } = new List<Competencium>();
}
