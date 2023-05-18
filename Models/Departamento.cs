using System;
using System.Collections.Generic;

namespace PROYECTORADIX.Models;

public partial class Departamento
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdPais { get; set; }

    public bool Estado { get; set; }

    public virtual Pai IdPaisNavigation { get; set; } = null!;

    public virtual ICollection<Municipio> Municipios { get; set; } = new List<Municipio>();
}
