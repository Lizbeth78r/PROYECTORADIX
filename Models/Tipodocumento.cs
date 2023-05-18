using System;
using System.Collections.Generic;

namespace PROYECTORADIX.Models;

public partial class Tipodocumento
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<Aprendiz> Aprendizs { get; set; } = new List<Aprendiz>();
}
