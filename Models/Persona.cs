using System;
using System.Collections.Generic;

namespace OzzyWeb1.Models;

public partial class Persona
{
    public int IdPersona { get; set; }

    public string? NoDocumento { get; set; }

    public string? TipoDocumento { get; set; }

    public string? Genero { get; set; }

    public string? NombrePersona { get; set; }

    public string? EmailPersona { get; set; }

    public string DireccionPersona { get; set; } = null!;

    public string? TelefonoPersona { get; set; }

    public int? IdRol { get; set; }

    public string? Contraseña { get; set; }

    public virtual ICollection<Acudiente>? Acudientes { get; set; } = new List<Acudiente>();

    public virtual ICollection<AdmiSisitema>? AdmiSisitemas { get; set; } = new List<AdmiSisitema>();

    public virtual ICollection<Estudiante>?Estudiantes { get; set; } = new List<Estudiante>();

    public virtual Rol? IdRolNavigation { get; set; }

    public virtual ICollection<Proveedor>? Proveedors { get; set; } = new List<Proveedor>();

    public virtual ICollection<Tutor>? Tutores { get; set; } = new List<Tutor>();
}
