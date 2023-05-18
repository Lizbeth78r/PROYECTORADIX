using System;
using System.Collections.Generic;

namespace PROYECTORADIX.Models;

public partial class Red
{
    public int Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdArea { get; set; }

    public bool Estado { get; set; }

    public virtual Area IdAreaNavigation { get; set; } = null!;

    public virtual ICollection<Programa> Programas { get; set; } = new List<Programa>();
}
