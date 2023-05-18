using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PROYECTORADIX.Models;

public partial class Area
{
    public int Codigo { get; set; }
    [Required(ErrorMessage = "[El id es obligatorio")]
    [RegularExpression("[0-9]{2}")]
    public string Nombre { get; set; } = null!;
    [Required(ErrorMessage = "[El id es obligatorio")]
    [RegularExpression("[a-zA-Z]")]
    public bool Estado { get; set; }
    public virtual ICollection<Red> Reds { get; set; } = new List<Red>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
