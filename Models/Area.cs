using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PROYECTORADIX.Models;

public partial class Area
{

    [Required(ErrorMessage = "El Código es obligatorio")]
    [RegularExpression("[0-9]")]
    public int Codigo { get; set; }

    [Required(ErrorMessage = "El Nombre es obligatorio")]
    [RegularExpression("[a-zA-Z]{2,20}")]
    public string Nombre { get; set; } = null!;
    public bool Estado { get; set; }
    public virtual ICollection<Red> Reds { get; set; } = new List<Red>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
