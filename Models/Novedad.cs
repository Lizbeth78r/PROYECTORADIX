using System;
using System.Collections.Generic;

namespace PROYECTORADIX.Models;

public partial class Novedad
{
    public int Id { get; set; }

    public int IdAprendiz { get; set; }

    public int IdUsuario { get; set; }

    public int IdTipoNovedad { get; set; }

    public DateTime FechaInicio { get; set; }

    public bool Estado { get; set; }

    public virtual Aprendiz IdAprendizNavigation { get; set; } = null!;

    public virtual TipoNovedad IdTipoNovedadNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
