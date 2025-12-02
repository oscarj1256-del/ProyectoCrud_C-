using System;
using System.Collections.Generic;

namespace OzzyWeb1.Models;

public partial class Notificación
{
    public int IdNotificación { get; set; }

    public string? CodigoNotificacion { get; set; }

    public string? Mensaje { get; set; }

    public string? FechaEnvio { get; set; }

    public string? Tipo { get; set; }

    public int? AdmiSisitemaIdAdmiSisitema { get; set; }

    public int? EstudianteIdEstudiante { get; set; }

    public virtual AdmiSisitema? AdmiSisitemaIdAdmiSisitemaNavigation { get; set; }

    public virtual Estudiante? EstudianteIdEstudianteNavigation { get; set; }
}
