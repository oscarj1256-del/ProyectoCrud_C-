using System;
using System.Collections.Generic;

namespace OzzyWeb1.Models;

public partial class Acudiente
{
    public int IdAcudiente { get; set; }

    public string? Autorizacion { get; set; }

    public int? PersonaIdPersona { get; set; }

    public int? IdEstudienteDependiente { get; set; }

    public virtual Estudiante? IdEstudienteDependienteNavigation { get; set; }

    public virtual Persona? PersonaIdPersonaNavigation { get; set; }
}
