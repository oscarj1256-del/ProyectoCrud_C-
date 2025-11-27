using System;
using System.Collections.Generic;

namespace OzzyWeb1.Models;

public partial class Inscripcion
{
    public int IdInscripcion { get; set; }

    public DateOnly FechaInscripcion { get; set; }

    public int EstudianteIdEstudiante { get; set; }

    public int? IdEstadoInscripcion { get; set; }

    public virtual Estudiante EstudianteIdEstudianteNavigation { get; set; } = null!;

    public virtual EstadoAdim? IdEstadoInscripcionNavigation { get; set; }
}
