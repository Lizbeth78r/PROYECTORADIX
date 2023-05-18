using System;
using System.Collections.Generic;

namespace PROYECTORADIX.Models;

public partial class TipoNovedad
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<Novedad> Novedads { get; set; } = new List<Novedad>();
}
