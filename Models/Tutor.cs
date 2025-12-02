using System;
using System.Collections.Generic;

namespace OzzyWeb1.Models;

public partial class Tutor
{
    public int IdTutor { get; set; }

    public string? Experiencia { get; set; }

    public string? Observaciones { get; set; }

    public int? PersonaIdPersona { get; set; }

    public virtual Persona? PersonaIdPersonaNavigation { get; set; }

    public virtual ICollection<Curso>? CursoIdCursos { get; set; } = new List<Curso>();
}
