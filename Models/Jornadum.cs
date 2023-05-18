using System;
using System.Collections.Generic;

namespace PROYECTORADIX.Models;

public partial class Jornadum
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<Ficha> Fichas { get; set; } = new List<Ficha>();
}
