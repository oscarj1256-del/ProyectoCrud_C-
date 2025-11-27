using System;
using System.Collections.Generic;

namespace OzzyWeb1.Models;

public partial class Rol
{
    public int IdRol { get; set; }

    public string? DescripcionRol { get; set; }

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
