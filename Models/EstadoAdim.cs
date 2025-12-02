using System;
using System.Collections.Generic;

namespace OzzyWeb1.Models;

public partial class EstadoAdim
{
    public int IdEstado { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<AdmiSisitema> AdmiSisitemas { get; set; } = new List<AdmiSisitema>();

    public virtual ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();

    public virtual ICollection<Inscripcion> Inscripcions { get; set; } = new List<Inscripcion>();
}
