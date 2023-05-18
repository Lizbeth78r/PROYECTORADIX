using System;
using System.Collections.Generic;

namespace PROYECTORADIX.Models;

public partial class Proyecto
{
    public int Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdPrograma { get; set; }

    public bool Estado { get; set; }

    public virtual Programa IdProgramaNavigation { get; set; } = null!;
}
