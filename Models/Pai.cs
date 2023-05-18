using System;
using System.Collections.Generic;

namespace PROYECTORADIX.Models;

public partial class Pai
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();
}
