﻿using System;
using System.Collections.Generic;

namespace PROYECTORADIX.Models;

public partial class TipoUsuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
