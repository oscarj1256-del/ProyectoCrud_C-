using System;
using System.Collections.Generic;

namespace OzzyWeb1.Models;

public partial class AdmiSisitema
{
    public int IdAdmiSisitema { get; set; }

    public string CodigoAdmin { get; set; } = null!;

    public int? IdEstadoAdministrador { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public string? UltimaConexión { get; set; }

    public int? PersonaIdPersona { get; set; }

    public virtual EstadoAdim? IdEstadoAdministradorNavigation { get; set; }

    public virtual ICollection<Notificación> Notificacións { get; set; } = new List<Notificación>();

    public virtual Persona? PersonaIdPersonaNavigation { get; set; }
}
